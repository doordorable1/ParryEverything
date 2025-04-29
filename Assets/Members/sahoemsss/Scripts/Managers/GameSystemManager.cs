using UnityEngine;

public class GameSystemManager : MonoBehaviour
{
    public static GameSystemManager Instance => _instance;
    static GameSystemManager _instance;

    public static PlayerHPChangeEvent PlayerHPChangeEvent => Instance._playerHpChangedEvent;
    PlayerHPChangeEvent _playerHpChangedEvent = new PlayerHPChangeEvent();

    public static BossDamageEvent BossDamageEvent => Instance._bossDamageEvent;
    BossDamageEvent _bossDamageEvent = new BossDamageEvent();

    public static ParryEnergyEvent ParryEnergyEvent => Instance._parryEnergyEvent;
    ParryEnergyEvent _parryEnergyEvent = new ParryEnergyEvent();

    private void Awake()
    {
        _instance = this;
    }
}
