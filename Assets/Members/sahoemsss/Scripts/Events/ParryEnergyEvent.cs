using System;

public class ParryEnergyEvent 
{
    public Action<int> OnGetParryEnergyEvent; // 패링 했을때 실행될 함수
    public Action<int> OnSetParryEnergyEvent; // 패링게이지 다 채우고 사용할때 사용할 변수 
    public Action<int> OnReactionEnergyEvent; // 에너지 바뀌었다고 알려줄 액션
    /// <summary>
    /// 패링을 했을때 게이지가 모이도록 
    /// </summary>
    /// <param name="getParryEnergy"></param>
    public void GetParryEnergy(int getParryEnergy)
    {
        OnGetParryEnergyEvent?.Invoke(getParryEnergy);
    }

    /// <summary>
    ///  모은 에너지를 방출 하는데 사용 
    /// </summary>
    /// <param name="useParryEnergy"></param>
    public void SetParryEnergy(int useParryEnergy = 0)
    {
        OnSetParryEnergyEvent?.Invoke(useParryEnergy);
    }

    public void ReactionEnergy(int energy)
    {
        OnReactionEnergyEvent?.Invoke(energy);
    }
}
