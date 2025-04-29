using UnityEngine;

public class PlayerArrow : MonoBehaviour
{
    const int DAMAGED = 6;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            GameSystemManager.BossDamageEvent.BossDamaged(DAMAGED);
        }
    }
}
