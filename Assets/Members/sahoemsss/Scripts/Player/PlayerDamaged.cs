using System.Collections;
using UnityEngine;

public class PlayerDamaged : MonoBehaviour
{
    PlayerParry _parry;
    BossCollider _bossCollider;
    const int DAMAGED = 1;

    private void Start()
    {
        _bossCollider = FindAnyObjectByType<BossCollider>(FindObjectsInactive.Include);
        _parry = FindAnyObjectByType<PlayerParry>();
    }

    // TODO : 적 투사체 판정에서 해당 적이 많은 것들을 가지고 잇다면 연속적으로 실행 되어서 하나 밖에 없는 플레이어를 다른 곳에서 액션으로 실행으로 바꿈 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossAttack"))
        {
            if (_parry.GetComponent<CircleCollider2D>().enabled)
                return;
            GameSystemManager.PlayerHPChangeEvent.PlayerDamaged(DAMAGED);
            StartCoroutine(BossColliderOnOff());
        }
    }

    IEnumerator BossColliderOnOff()
    {
        _bossCollider.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        _bossCollider.gameObject.SetActive(true);
    }

}
