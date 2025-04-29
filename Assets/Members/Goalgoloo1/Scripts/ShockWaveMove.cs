using UnityEngine;

public class ShockWaveMove : MonoBehaviour
{
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    private float moveSpeed;

    void Update()
    {
        transform.position += new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
    }
}
