using UnityEngine;

public class PlayerDamager : MonoBehaviour
{
    const int DAMAGED = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!PlayerStateManager.IsPlayerParry)
            {
                GameSystemManager.PlayerHPChangeEvent.PlayerDamaged(DAMAGED);
            }
        }
    }
}
