using UnityEngine;

public class PlayerEnergyState : MonoBehaviour
{
    public int PlayerEnergy
    {
        get
        {
            return _playerEnergy;
        }
        set
        {
            _playerEnergy = value;
            ReactionEnergy(_playerEnergy);
        }
    }

    int _playerEnergy = 0;

    private void Start()
    {
        GameSystemManager.ParryEnergyEvent.OnGetParryEnergyEvent += GetEnergy;
        GameSystemManager.ParryEnergyEvent.OnSetParryEnergyEvent += SetEnergy;
    }

    void GetEnergy(int energy)
    {
        if (PlayerEnergy >= 5)
            return;
        PlayerEnergy += energy;
    }

    void SetEnergy(int energy)
    {
        PlayerEnergy = 0;
    }

    void ReactionEnergy(int energy)
    {
        GameSystemManager.ParryEnergyEvent.ReactionEnergy(energy);
    }

}
