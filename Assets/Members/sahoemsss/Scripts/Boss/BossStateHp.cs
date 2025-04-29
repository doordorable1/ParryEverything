using UnityEngine;

public class BossStateHp : MonoBehaviour
{
    public int BossHP
    {
        get
        {
            return _bossHP;
        }
        set
        {
            _bossHP = value;
            ReactionChangeHP(_bossHP);
        }
    }

    int _bossHP = 100;

    private void Start()
    {
        GameSystemManager.BossDamageEvent.OnBossDamagedEvent += ChangeHP;
    }

    void ChangeHP(int damaged)
    {
        for (int i = 0; i < damaged; i++)
        {
            BossHP --;
        }
        
    }

    void ReactionChangeHP(int bosshp)
    {
        GameSystemManager.BossDamageEvent.BossHPReaction(bosshp);
    }

}
