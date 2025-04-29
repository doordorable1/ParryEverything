using UnityEngine;

/// <summary>
/// TODO: 지금 받아 오는 것들을 New Input으로 바꿔야 됨 
/// </summary>
public class PlayerSpecialAttack : MonoBehaviour
{
    PlayerShootPos _shootPos;
    bool _canSpecialAttack = false;
    GameObject _playerEnergyShoot;
    Vector2 dir;
    const float SPECIAL_ATTACK_SPEED = 40f;

    private void Start()
    {
        _playerEnergyShoot = Resources.Load<GameObject>("PlayerEnergy/Player Arrow");
        _shootPos = FindAnyObjectByType<PlayerShootPos>();
        GameSystemManager.ParryEnergyEvent.OnReactionEnergyEvent += GetEnergyFull;
        Managers.InputManager.OnSpacialAttackEvent += SpecialAttack;
    }

    void SpecialAttack()
    {
        if (!_canSpecialAttack)
            return;
        dir = (_shootPos.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;// 90f; // 상단 0도 기준
        GameObject go = Instantiate(_playerEnergyShoot, transform.position, Quaternion.Euler(0f, 0f, angle));

        go.GetComponent<Rigidbody2D>().AddForce(dir * SPECIAL_ATTACK_SPEED, ForceMode2D.Impulse);
        if (dir.x < 0)
            go.GetComponent<SpriteRenderer>().flipY = true;
       
        // TODO : 플레이어 에너지 쏘는 애니 재탕
        PlayerStateManager.PlayerAni.Play("PlayerParry");
        _canSpecialAttack = false;
        GameSystemManager.ParryEnergyEvent.SetParryEnergy();
    }

    void GetEnergyFull(int energy)
    {
        if (energy == 5)
        {
            _canSpecialAttack = true;
        }
    }


}
