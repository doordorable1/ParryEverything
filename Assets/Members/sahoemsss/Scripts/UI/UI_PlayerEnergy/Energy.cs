using UnityEngine;

public class Energy : MonoBehaviour
{
    public int energy;

    private void Start()
    {
        GameSystemManager.ParryEnergyEvent.OnReactionEnergyEvent += ChangeEnergy;
        gameObject.SetActive(false);
    }

    void ChangeEnergy(int playerEnergy)
    {
        if (energy <= playerEnergy)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
