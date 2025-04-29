using System;

/// <summary>
/// TODO: 현재는 수치 가 int형 위주의 값이지만 나중에 플레이어의 체력을 Float으로 구현 할 것이라면 따로 다시 구현 해야 한다.
/// </summary>
public class PlayerHPChangeEvent
{
    public Action<int> OnPlayerDamagedEvent; 
    public Action<int> OnPlayerHPReactionEvent;

    public void PlayerDamaged(int damaged)
    {
        OnPlayerDamagedEvent?.Invoke(damaged);
    }

    public void PlayerHPReaction(int playerHP)
    {
        OnPlayerHPReactionEvent?.Invoke(playerHP);
    }
    
}
