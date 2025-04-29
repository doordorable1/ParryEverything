using System.Collections;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    float _gravityStrength;
    float _gravityScale;
    float _normalGravityScale;
    private float _jumpForce;

    float _canJumpTime;

   const float JumpHight = 50; 
   const float JumpTimeToApex = 1.0f; 
   const float JumpBufferTime = 0.05f; 
   const float FallGravityMultiplier = 0.8f; 
   const float MaxFallSpeed = 25f; 

    private void Start()
    {
        Managers.InputManager.OnJumpEvent += Jump;  

        _gravityStrength = -(2 * JumpHight) / (JumpTimeToApex * JumpTimeToApex); 
        _gravityScale = _gravityStrength / Physics2D.gravity.y; 
        _normalGravityScale = _gravityScale; 
        _jumpForce = Mathf.Abs(_gravityStrength) * JumpTimeToApex; 

        Managers.InputManager.OnJumpCutEvent += JumpCutGravity; 
    }

    private void Update()
    {
        _canJumpTime -= Time.deltaTime; 

        if (_canJumpTime > 0 && PlayerStateManager.IsGrounded)
        {
            Jump();
        }

        if (PlayerStateManager.PlayerRigid.linearVelocity.y > MaxFallSpeed) 
        {
            
            PlayerStateManager.PlayerRigid.linearVelocity = new Vector2(PlayerStateManager.PlayerRigid.linearVelocity.x, MaxFallSpeed);
        }

        if (PlayerStateManager.PlayerRigid.linearVelocity.y < 0)
        {
            PlayerStateManager.PlayerRigid.gravityScale = _gravityScale * FallGravityMultiplier;
        }
        else 
            PlayerStateManager.PlayerRigid.gravityScale = _gravityScale;
    }


    private void Jump()
    {
        
        _canJumpTime = JumpBufferTime; 

        if (PlayerStateManager.IsJumping) 
        {
            return;
        }

        if (PlayerStateManager.LastGroundTimer > 0) 
        {
            PlayerStateManager.IsJumpEndAni = false;
            PlayerStateManager.PlayerAni.Play("PlayerJumpStart");
            if (!PlayerStateManager.IsGrounded)
            {
                PlayerStateManager.PlayerRigid.AddForce(Vector2.up * _jumpForce * 1.5f, ForceMode2D.Impulse);
            }
            else 
                PlayerStateManager.PlayerRigid.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            StartCoroutine(WaitOneSecondCouroutine()); 
        }

    }

    void JumpCutGravity()
    {
        PlayerStateManager.PlayerAni.Play("PlayerJumping");
        _gravityScale = _gravityScale * FallGravityMultiplier; 
        PlayerStateManager.PlayerRigid.AddForce(Vector2.down * _gravityScale, ForceMode2D.Impulse);
        _gravityScale = _normalGravityScale; 
    }

    IEnumerator WaitOneSecondCouroutine()
    {
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        PlayerStateManager.IsJumping = true;

    }

    private void OnDisable()
    {
        Managers.InputManager.OnJumpEvent -= Jump; 
        Managers.InputManager.OnJumpCutEvent -= JumpCutGravity; 
    }
}