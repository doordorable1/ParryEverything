using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public static PlayerStateManager Instance => _instance;
    static PlayerStateManager _instance;
    public static Rigidbody2D PlayerRigid => Instance._playerRigid;

    public static float PlayerSpeed => Instance._playerSpeed;
    public static float PlayerJumpPower => Instance._playerJumpPower;
    public static float LastGroundTimer => Instance._lastGroundedTimer;

    public static Animator PlayerAni => Instance._playerAni;
    /// <summary>
    /// 점프 애니메이션 판정 
    /// </summary>
    public static bool IsJumpEndAni
    {
        get
        {
            return Instance._isJumpEndAni;
        }
        set
        {
            Instance._isJumpEndAni = value;
        }
    }

    public static bool IsPlayerParry
    {
        get
        {
            return Instance._isPlayerParryAni;
        }
        set
        {
            Instance._isPlayerParryAni = value;
        }
    }

    /// <summary>
    /// 땅 판정 
    /// </summary>
    public static bool IsGrounded
    {
        get
        {
            return Instance._isGrounded;
        }
        set
        {
            Instance._isGrounded = value;
        }
    }
    public static bool IsJumping
    {
        get
        {
            return Instance._isJumping;
        }
        set
        {
            Instance._isJumping = value;
        }
    }
    public static bool FilpX
    {
        get
        {
            return Instance._filpX;
        }
        set
        {
            Instance._filpX = value;
        }
    }

    #region 버려도 되는 애들 
    /// <summary>
    /// 사실상 필요 없음 대쉬 없어서 
    /// </summary>
    public static bool IsDashing
    {
        get
        {
            return Instance._isDashing;
        }
        set
        {
            Instance._isDashing = value;
        }
    }
    
    /// <summary>
    /// 공격도 이제 없음 
    /// </summary>
    public static bool IsAttacking
    {
        get { return Instance._isAttacking; }
        set { Instance._isAttacking = value; }
    }

    public static int Combo
    {
        get { return Instance._combo; }
        set { Instance._combo = value; }
    }

    public static bool IsAttackCooltime
    {
        get { return Instance._isAttackCooltime; }
        set { Instance._isAttackCooltime = value; }
    }


    #endregion
    public static bool IsDeath
    {
        get { return Instance._isDeath; }
        set { Instance._isDeath = value; }
    }

    Rigidbody2D _playerRigid;
    float _playerSpeed = 14.5f;//9.5f; 
    float _playerJumpPower = 30f;

    Transform _groundCheckPoint; 
    Vector2 _groundCheckSize = new Vector2(0.49f, 0.02f); 
    LayerMask _groundLayer = 1 << 6;

    Animator _playerAni;
    bool _isJumpEndAni = false;
    bool _isPlayerParryAni = false;

    float _lastGroundedTimer;
    bool _isJumping = false;
    bool _isGrounded = true;
    const float JumpCoyoteTime = 0.1f;
    bool _filpX = false;

    #region 필요 없는 변수 
    bool _isDashing = false;
    bool _isAttacking = false;
    int _combo = 0;
    bool _isAttackCooltime = false;
    #endregion

    bool _isDeath = false;

    private void Awake()
    {
        _instance = this;
        Init();
    }
    
    private void Update()
    {
        _lastGroundedTimer -= Time.deltaTime;
        IsGrounded = isGrounded();
    }

    void Init()
    {
        _playerAni = GetComponent<Animator>();
        _groundCheckPoint = GetComponentInChildren<PlayerGroundCheckPos>().transform;
        _playerRigid = GetComponent<Rigidbody2D>();
    }

    bool isGrounded()
    {
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
        {
            _lastGroundedTimer = JumpCoyoteTime;
            _isJumping = false;
            _isGrounded = true;

            if (!_isJumpEndAni)
            {
                _playerAni.Play("PlayerJumpEnd");
                _isJumpEndAni = true;
            }
        }
        else
        {
            _isGrounded = false;
        }
        return _isGrounded;
    }
}