using UnityEngine;

public class ParryRange : MonoBehaviour
{
    // TODO: 수치 값이 그냥 velocity로 하는게 좋아 보이긴 함
    // TODO: 일단 구현 자체는 여기서 하는게 좋아 보이긴 함 
    GameObject _parryEffect;

    const float ARROW_SPEED = 10f;
    const float PARRYFORCE = 300f;
    const int GET_PARRY_ENERGY = 1;
    const int DAMAGED = 1;
    const int BOSSDAMAGED = 3;
    private void Start()
    {
        //TODO : 일단 패링 이펙트 변경 
        _parryEffect = Resources.Load<GameObject>("Effect/ParryEffect");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            if (collision != null )
            {
                //TODO : CameraShaking 넣어 달라고 요청 옴 
                //TODO: Parry 했을때 게이지 채워 줘야됨 
                GameSystemManager.ParryEnergyEvent.GetParryEnergy(GET_PARRY_ENERGY);
                Debug.Log("패링 했습니다");
                GameObject go = Instantiate(_parryEffect, transform.position, Quaternion.identity);
                //Vector2 dir = collision.gameObject.transform.position - transform.position;
                Vector2 dir = -collision.gameObject.GetComponent<EnemyBullet>().DIR;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(dir * ARROW_SPEED * PARRYFORCE);
                collision.tag = "PlayerParryObj";
                collision.name = "PlayerParryObj";
                FindAnyObjectByType<K_Camera>().CamShake();
            }
          
        }
        if (collision.CompareTag("BossAttack"))
        {
            if (collision != null)
            {
                GameSystemManager.ParryEnergyEvent.GetParryEnergy(GET_PARRY_ENERGY);
                GameObject go = Instantiate(_parryEffect, transform.position, Quaternion.identity);
                GameSystemManager.BossDamageEvent.BossDamaged(BOSSDAMAGED);
                FindAnyObjectByType<K_Camera>().CamShake();
            }

        }
    }
}
