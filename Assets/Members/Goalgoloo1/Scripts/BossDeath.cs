using BehaviorDesigner.Runtime;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    Boss _boss;
    Animator _ani;
    BehaviorTree _behavior;
    void Start()
    {
        _behavior = GetComponent<BehaviorTree>();
        _ani = GetComponent<Animator>();
        _boss = GetComponent<Boss>();
       // GameSystemManager.BossDamageEvent.OnBossHpReactionEvent += BossDeaths;
        GameSystemManager.BossDamageEvent.OnBossDeathEvent += BossDeaths;
    }

    void BossDeaths(int bossHp)
    {
        if (bossHp <= 0)
        {
            // TODO: 보스 사망 애니메이션
            // TOOD : 보스 사망시 SetTrigger로 동작하는데 최적화 안좋긴함 수정 할때 같이 수정 
            _behavior.enabled = false;
            Destroy(_behavior);
            Destroy(FindAnyObjectByType<BehaviorManager>().gameObject);
            _ani.SetTrigger("newBossDeath");
            // TODO: 여기에 승리 했을때 UI 추가 
            // Action으로 하면 되는데 현재 GameProgress에 싱글톤으로 처리 되어 있어서 
            // 해당 UI의 방식을 Action 실행 되었을때 Canvas를 켜주는 방식으로 바꾸는 것이 좋아 보인다 
            // 싱글톤을 사용하지 않아도 되는 부분에서 사용하고 있는 것 같다 
            // GamaProgress를 옮겨 와야 됨 
        }
    }
}
