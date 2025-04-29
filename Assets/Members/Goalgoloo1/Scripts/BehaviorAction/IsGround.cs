using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsGround : Conditional
{
    public float rayLength = 0.6f; 
    public LayerMask groundLayer; 
    public bool isGrounded; 

    public override void OnStart()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        if (isGrounded == false)
            GetComponent<AI>().transform.Rotate(0, 180, 0);// = -GetComponentInParent<AI>().moveDirection;
    }
    public override TaskStatus OnUpdate()
    {
        return isGrounded ? TaskStatus.Success : TaskStatus.Running;
    }
    public override void OnEnd()
    {
        
    }

    

}
