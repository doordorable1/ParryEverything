using UnityEngine;

/// <summary>
/// Testing Code
/// </summary>
public class EnemyArrowShooter : MonoBehaviour
{
    Player _player;
    GameObject _enemyBullet;
    float _random;

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
        _enemyBullet = Resources.Load<GameObject>("Test/EnemyBullet");
        _random = Random.Range(0.5f, 3f);
        InvokeRepeating("ShootBullet", 0, _random);
    }

    private void Update()
    {
        if (_player== null)
            return;

        Vector2 direction = ((Vector2)_player.transform.position - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f; // 상단 0도 기준
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    
}
