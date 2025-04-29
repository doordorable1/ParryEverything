
using UnityEngine;

public class PlayerHPState : MonoBehaviour
{
    public int PlayerHP
    {
        get
        {
            return _playerHP;
        }
        set
        {
            _playerHP = value;
            ReactionHPChange(_playerHP);
        }
    }

    int _playerHP = 10;

    private void Start()
    {
        GameSystemManager.PlayerHPChangeEvent.OnPlayerDamagedEvent += ChangeHP;
    }

    void ChangeHP(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            PlayerHP --;

        }
    }

    void ReactionHPChange(int playerHP)
    {
        GameSystemManager.PlayerHPChangeEvent.PlayerHPReaction(playerHP);
    }

}
