using UnityEngine;

public class BossHPTester : MonoBehaviour
{
    const int DAMAGED = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameSystemManager.BossDamageEvent.BossDamaged(DAMAGED);
        }
    }
}
