using UnityEngine;

public class ShootEnemyBullet : MonoBehaviour
{
    GameObject _enemyBullet;
    float _random;

    private void Start()
    {
        _enemyBullet = Resources.Load<GameObject>("Test/EnemyBullet");
        _random = Random.Range(0.5f, 3f);
        InvokeRepeating("ShootBullet", 0, _random);
    }
    void ShootBullet()
    {
        GameObject go = Instantiate(_enemyBullet, transform.position, Quaternion.identity);
        Destroy(go, 3f);
    }
}
