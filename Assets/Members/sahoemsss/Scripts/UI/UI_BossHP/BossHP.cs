using UnityEngine;

public class BossHP : MonoBehaviour
{
    public int bossHp;

    void Start()
    {
        GameSystemManager.BossDamageEvent.OnBossHpReactionEvent += BossHPChange;
    }

    void BossHPChange(int _bossHP)
    {
        if (bossHp == _bossHP / 10)
        {
            if (bossHp == 0)
                GameSystemManager.BossDamageEvent.BossDeath(bossHp);
            Destroy(this.gameObject);
        }
    }
    void OnDestroy()
    {
        GameSystemManager.BossDamageEvent.OnBossHpReactionEvent -= BossHPChange;
    }
}
