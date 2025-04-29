using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public bool hitDestroy;
    const int DAMAGED = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {


            if (collision.GetComponentInChildren<CircleCollider2D>().enabled == true) return;


            if (!PlayerStateManager.IsPlayerParry)
            {
                GameSystemManager.PlayerHPChangeEvent.PlayerDamaged(DAMAGED);
                if (hitDestroy) Destroy(gameObject);
            }
        }
    }
}
