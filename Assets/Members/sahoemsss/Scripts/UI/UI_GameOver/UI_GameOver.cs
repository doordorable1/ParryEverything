using UnityEngine;

public class UI_GameOver : MonoBehaviour
{
    Canvas _canvas;
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        GameSystemManager.PlayerHPChangeEvent.OnPlayerHPReactionEvent += DefeatScreen;
    }

    void DefeatScreen(int playerHp)
    {
        if (playerHp <= 0)
        {
            _canvas.enabled = true; 
            Time.timeScale = 0;
        }
    }
}
