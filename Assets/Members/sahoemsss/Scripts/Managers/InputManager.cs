using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    public InputSystem_Actions MyPlayerInputSystem => _myPlayerInputSystem;
    public InputAction MoveAction => _moveAction;
    public InputAction JumpAction => _jumpAction;
    public InputAction ParryAction => _parryAction;
    public InputAction SpecialAction => _spacialAttack;

    public Vector2 MoveVec => _moveVector;
    public bool IsMove => _isMove;
    public bool IsJumpPress => _isJumpPress;
    public bool IsJumpCut
    {
        get
        {
            return _isJumpCut;
        }
        set
        {
            _isJumpCut = value;
        }
    }
    public bool IsMoveable
    {
        get
        {
            return _isMoveable;
        }
        set
        {
            _isMoveable = value;
        }
    }
    /// <summary>
    /// 패리가 가능한지 아닌지 여부
    /// </summary>
    public bool IsParryAble
    {
        get
        {
            return _isParry;
        }
        set
        {
            _isParry = value;
        }
    }
    public bool IsOption
    {
        get
        {
            return _isOption;
        }
        set
        {
            _isOption = value;
        }
    }

    InputSystem_Actions _myPlayerInputSystem; // 나의 InputSystem 가져오기
    PlayerInput _playerInput;
    InputAction _moveAction; // 움직임 Action
    InputAction _jumpAction; // 점프 Action
    InputAction _parryAction; // 패링 Action
    InputAction _spacialAttack; // 특별 Action

    Vector2 _moveVector; // 움직인 값을 받아 오기 위한 벡터 
    bool _isMove; // 현재 움직이는가?
    bool _isJumpCut;
    bool _isJumpPress; // 점프 뛰었을때 
    bool _isMoveable;
    bool _isParry; // 현재 패리 중인가?

    bool _isOption; // 옵션창이 켜져있는지

    public Action OnJumpEvent; // Jump 되었을때 Action 실행 
    public Action OnJumpCutEvent; // OnJumpCut Action
    public Action OnParryEvent; // 패링 했을때 이벤트 
    public Action OnSpacialAttackEvent; // 특공 이벤트 
    public void Init()
    {
        _myPlayerInputSystem = new InputSystem_Actions(); // 내 InputSystem 가져옴
        _playerInput = GameObject.FindAnyObjectByType<PlayerInput>();
        _playerInput.neverAutoSwitchControlSchemes = true;
        _moveAction = _myPlayerInputSystem.MyPlayer.Move; // 내 InputSystem에서 해당 Action이 어떤 액션 을 참조하는지 
        _jumpAction = _myPlayerInputSystem.MyPlayer.Jump;
        _parryAction = _myPlayerInputSystem.MyPlayer.Parry; // 패링 액션을 넘겨줌 
        _spacialAttack = _myPlayerInputSystem.MyPlayer.SpacialAttack;

        _myPlayerInputSystem.MyPlayer.Enable();
        _moveAction.Enable(); // 연결 
        _jumpAction.Enable();
        _parryAction.Enable();
        _spacialAttack.Enable();

        _moveAction.performed += OnMove; // 어떤 함수 실행일지 연결 
        _moveAction.canceled += OnMove;

        _jumpAction.started += OnJump;
        _jumpAction.canceled += OnJump;

        _parryAction.performed += OnParry;

        _spacialAttack.performed += OnSpacialAttack;

        _isJumpCut = false;
        _isMoveable = true;
        _isParry = false; // 페링 상태가 아니다라고 말해놓음 

        _isOption = false;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        if (_isOption) return;
        if (!_isMoveable) return;

        if (context.phase == InputActionPhase.Performed)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            _moveVector = moveInput;
            if (_moveVector.x > 0.01f || _moveVector.x < -0.01f)
                _isMove = true;
            else if (_moveVector.x < 0.01f || _moveVector.x > -0.01f)
                _isMove = false;
        }

        else if (context.phase == InputActionPhase.Canceled)
        {
            _moveVector = Vector2.zero;
            _isMove = false;
        }
    }

    void OnJump(InputAction.CallbackContext context)
    {
        if (_isOption) return;
        if (!_isMoveable) return;

        if (context.phase == InputActionPhase.Started)
        {
            OnJumpEvent?.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            if (PlayerStateManager.IsJumping && PlayerStateManager.PlayerRigid.linearVelocity.y > 0)
            {
                _isJumpCut = true;
                OnJumpCutEvent?.Invoke();
            }
        }
    }

    void OnParry(InputAction.CallbackContext context)
    {
        if (_isOption) return;
        if (_isParry) return;

        if (context.phase == InputActionPhase.Performed)
        {
            OnParryEvent?.Invoke();
        }
    }

    void OnSpacialAttack(InputAction.CallbackContext context)
    {
        if (_isOption) return;

        if (context.phase == InputActionPhase.Performed)
        {
            OnSpacialAttackEvent?.Invoke();
        }
    }

    /// <summary>
    /// 플레이어가 죽었을때 실행 시킬 Clear
    /// </summary>
    public void Clear()
    {
        _moveAction.Disable();
        _jumpAction.Disable();
        _parryAction.Disable();
        _spacialAttack.Disable();

        _myPlayerInputSystem.MyPlayer.Disable();
        OnJumpEvent = null;
    }
}