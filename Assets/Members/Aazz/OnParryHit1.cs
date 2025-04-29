using UnityEngine;

public class OnParryHit1 : MonoBehaviour
{
    GameObject _parryEffect;
    private void Start()
    {
        _parryEffect = Resources.Load<GameObject>("Effect/PlayerParryEffect");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            GameObject go = Instantiate(_parryEffect, transform.position, Quaternion.identity);

            GetComponentInParent<BossStateHp>().BossHP -= 1;


            FindAnyObjectByType<K_Camera>().CamShake();

        }
    }
}
