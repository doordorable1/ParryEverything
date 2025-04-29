using System;

public class BossDamageEvent 
{
    public Action<int> OnBossDamagedEvent;
    public Action<int> OnBossHpReactionEvent;
    public Action<int> OnBossDeathEvent; 
    public void BossDamaged(int damage)
    {
        OnBossDamagedEvent?.Invoke(damage);
    }

    public void BossHPReaction(int bosshp)
    {
        OnBossHpReactionEvent?.Invoke(bosshp);
    }

    public void BossDeath(int bossHp)
    {
        OnBossDeathEvent?.Invoke(bossHp);
    }
}
