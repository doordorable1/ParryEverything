using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void GameExit()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }
}
