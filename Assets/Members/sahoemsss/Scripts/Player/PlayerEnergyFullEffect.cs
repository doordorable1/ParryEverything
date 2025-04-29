using UnityEngine;

public class PlayerEnergyFullEffect : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        GameSystemManager.ParryEnergyEvent.OnReactionEnergyEvent += OnEffect;
    }

    void OnEffect(int energy)
    {
        if (energy == 5)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
    
}
