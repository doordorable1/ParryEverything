using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 DIR => _dir;
    Rigidbody2D _rigid2D;
    Player _player;
    PlayerParry _parry;
    Vector2 _dir;
    const float CONST_SPEED = 20f;
    const float BULLET_SPEED = 30f;
    GameObject _effect;

    private void Start()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
        _player = FindAnyObjectByType<Player>();
        _parry = FindAnyObjectByType<PlayerParry>();
        _effect = Resources.Load<GameObject>("Effect/HitEffect");

        _dir = (_player.transform.position - transform.position).normalized;
        _rigid2D.AddForce(_dir * CONST_SPEED * BULLET_SPEED);
    }

    const int DAMAGED = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!_parry.GetComponent<CircleCollider2D>().enabled)
            {
                GameSystemManager.PlayerHPChangeEvent.PlayerDamaged(DAMAGED);
                Destroy(Instantiate(_effect, transform.position, Quaternion.identity), 5);
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("Ground"))
        {

            Destroy(Instantiate(_effect, transform.position, Quaternion.identity), 5);
            Destroy(gameObject);
        }

    }

}
