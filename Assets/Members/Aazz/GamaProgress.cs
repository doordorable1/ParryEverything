using UnityEngine;

public class GamaProgress : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject winScreen;
    public GameObject DdefeatScreen;
    
    void Start()
    {
        GameSystemManager.BossDamageEvent.OnBossHpReactionEvent += WinWating;
        GameSystemManager.PlayerHPChangeEvent.OnPlayerHPReactionEvent += DefeatScreen;
    }
   
   void WinWating(int bossHP) 
   {
        if (bossHP <= 0)
        {
            // TODO: 죽는 장면에 대한 2초정도 넣어 주면 된다고 이야기 
            Time.timeScale = 0.5f;

            Invoke("WinWait", 2);
        }
    }
    void WinWait() { winScreen.SetActive(true); Time.timeScale = 0; }

    void DefeatScreen(int playerHp)
    {
        if (playerHp <= 0)
        {
            DdefeatScreen.SetActive(true); Time.timeScale = 0; 
            //Invoke("DefeatWait",2);
             //Time.timeScale = 0.5f;
        }
    }
    void DefeatWait() { }
}
