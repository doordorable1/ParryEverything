using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int playerHP;

    private void Start()
    {
        GameSystemManager.PlayerHPChangeEvent.OnPlayerHPReactionEvent += ChangeHP;
    }

    void ChangeHP(int playerHPReact)
    {
        if (playerHP == playerHPReact)
        {
            Destroy(gameObject);
        }
    }
}
