using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Transform _groundCheckPoint; 
    Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f); 
    LayerMask _groundLayer = 1 << 6;  

    bool _isFacingRight = true; 
    float _lastOnGroundTime; 

    float _runAceelAmount =  7f; 
    float _runDeccelAmount = 7f;

    float _accelInAir = 1f; 
    float _deccelInAir = 1f; 

    bool _doConserveMomentum = true; 

    //SpriteRenderer _playerSpriteRenderer;

    public bool IsFacingRight => _isFacingRight;

    private void Start()
    {
        _groundCheckPoint = GetComponentInChildren<PlayerGroundCheckPos>().transform;
       // _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _lastOnGroundTime -= Time.deltaTime;

        IsGrounded();
        Flip();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float playerSpeed = Managers.InputManager.MoveVec.x * PlayerStateManager.PlayerSpeed;
        float accelRate;
        if (!PlayerStateManager.IsPlayerParry && !PlayerStateManager.IsJumping)
        {
            if (Mathf.Abs(Managers.InputManager.MoveVec.x) == 0)
                PlayerStateManager.PlayerAni.Play("PlayerIDLE");
            else
                PlayerStateManager.PlayerAni.Play("PlayerMove");
        }
        
        if (_lastOnGroundTime > 0)
            accelRate = (Mathf.Abs(playerSpeed) > 0.01f) ? _runAceelAmount : _runDeccelAmount;
        else
            accelRate = (Mathf.Abs(playerSpeed) > 0.01f) ? _runAceelAmount * _accelInAir : _runDeccelAmount * _deccelInAir;

        if (_doConserveMomentum && Mathf.Abs(PlayerStateManager.PlayerRigid.linearVelocity.x) > Mathf.Abs(playerSpeed)
            && Mathf.Sign(PlayerStateManager.PlayerRigid.linearVelocity.x) == Mathf.Sign(playerSpeed) && Mathf.Abs(playerSpeed) > 0.01f
            && _lastOnGroundTime < 0)
        {
            accelRate = 0;
        }


        float speedDif = playerSpeed - PlayerStateManager.PlayerRigid.linearVelocity.x;
        float moveMent = speedDif * accelRate; 

        PlayerStateManager.PlayerRigid.AddForce(moveMent * Vector2.right, ForceMode2D.Force); // 해당 방향으로 힘을 줘서 가속하거나 감속함
    }

    void Flip()
    {
        if (Managers.InputManager.MoveVec.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            PlayerStateManager.FilpX = true;
        }
        else if (Managers.InputManager.MoveVec.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            PlayerStateManager.FilpX = false;
        }
    }

    void IsGrounded()
    {
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
            _lastOnGroundTime = 0.1f;
    }
}