using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public float rayLength = 0.6f; // 레이 길이
    public LayerMask groundLayer; // 바닥 레이어


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = Physics2D.Raycast(transform.position , Vector2.down, rayLength, groundLayer);
        if (isGrounded == false)
            GetComponentInParent<AI>().transform.Rotate(0, 180, 0);// = -GetComponentInParent<AI>().moveDirection;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayLength);

    }
}
