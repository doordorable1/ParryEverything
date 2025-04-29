using UnityEngine;

public class Ui_GameClear : MonoBehaviour
{
    Canvas _canvas;
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        GameSystemManager.BossDamageEvent.OnBossDeathEvent += WinWating;
    }

    void WinWating(int bossHP)
    {
        Time.timeScale = 0.5f;
        Invoke("WinWait", 2);
    }

    void WinWait() 
    {
        _canvas.enabled = true; 
        Time.timeScale = 0; 
    }
}
