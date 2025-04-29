using UnityEngine;

public class EnemyDamaged : MonoBehaviour
{
    EnemyHP _enemyHp;

    private void Start()
    {
        _enemyHp = GetComponent<EnemyHP>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerParryObj"))
        {
            _enemyHp.HP--;
        }
        if (collision.CompareTag("PlayerEnergyArrow"))
        {
            _enemyHp.HP -= 3;
        }
    }
}
