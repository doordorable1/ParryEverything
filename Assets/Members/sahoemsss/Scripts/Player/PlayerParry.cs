using UnityEngine;

/// <summary>
/// 패링의 판정 자체를 Dir로 해야할 가능성이 농후하다.
/// </summary>
public class PlayerParry : MonoBehaviour
{
    float _parryOfftimer = 0;
    const float CAN_PARRY_TIME = 0.35f;
    const float IS_PARRY = 0.295f; //너무어려워서 0.275->0.295 상향

    // TODO : 패링 지연 시간 만들어 놔야 될 듯?
    void Start()
    {
        Managers.InputManager.OnParryEvent += Parry;
    }

    private void Update()
    {
        if (Managers.InputManager.IsParryAble)
            _parryOfftimer += Time.deltaTime;
        if (_parryOfftimer > IS_PARRY)
        {
            PlayerStateManager.IsPlayerParry = false;
        }

        if (_parryOfftimer > CAN_PARRY_TIME && Managers.InputManager.IsParryAble)
        {
            Managers.InputManager.IsParryAble = false;
            _parryOfftimer = 0; 
        }
    }

    void Parry()
    {
        if (PlayerStateManager.IsJumping)
            return;
        PlayerStateManager.PlayerAni.Play("PlayerParry");
        PlayerStateManager.IsPlayerParry = true;
        Managers.InputManager.IsParryAble = true;
        // 패링은 여기서 판정이 아니라 OnTrigger에서 판정 하면 더 빠르게 판정 할 수 있다.
        // 정확한 판정 수치가 필요 하기 때문에 OnTrigger를 이용한 패링 판정이 필요하다.
    }

}
