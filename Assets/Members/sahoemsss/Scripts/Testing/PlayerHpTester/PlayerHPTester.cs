using UnityEngine;

public class PlayerHPTester : MonoBehaviour
{
    const int DAMAGED = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameSystemManager.PlayerHPChangeEvent.PlayerDamaged(DAMAGED);
        }
    }
}
