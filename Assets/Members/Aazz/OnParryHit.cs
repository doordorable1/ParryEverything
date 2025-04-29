using UnityEngine;

public class OnParryHit : MonoBehaviour
{
    public bool hitDestroy;
    GameObject _parryEffect;
    public int damage = 1;

    private void Start()
    {
        _parryEffect = Resources.Load<GameObject>("Effect/ParryEffect");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            //TODO : 근접 잡몹 공격 판정 처리 부분 
            GameSystemManager.ParryEnergyEvent.GetParryEnergy(1);
            GameObject go = Instantiate(_parryEffect, FindAnyObjectByType<PlayerParry>().transform.position, Quaternion.identity);



            FindAnyObjectByType<K_Camera>().CamShake();






            var info = GetComponent<Info>();
            if (info != null)
            {
                info.owner.GetComponent<EnemyHP>().HP = info.owner.GetComponent<EnemyHP>().HP - damage;
            }



            var boss = GetComponentInParent<BossStateHp>();
            if (boss != null && damage>0) 
            {
                GetComponentInParent<BossStateHp>().BossHP -= damage;
            }


            if (hitDestroy)
            { Destroy(gameObject); GetComponent<Collider2D>().enabled = false; return; }
        }
    }
}
