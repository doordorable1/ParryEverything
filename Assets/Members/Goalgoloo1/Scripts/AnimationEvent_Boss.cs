using Unity.VisualScripting;
using UnityEngine;

public class AnimationEvent_Boss : MonoBehaviour
{
    GameObject _shockWave;
    float _shockWaveSpeed = 10f;

    void Start()
    {
        _shockWave = Resources.Load<GameObject>("BossAttack/shockwave");
    }

    public void InstanceShockWave()
    {
        Vector2 posforward = new Vector2(transform.position.x, transform.position.y);
        GameObject goLeft = Instantiate(_shockWave, posforward, Quaternion.identity);
        GameObject goRight = Instantiate(_shockWave, posforward, Quaternion.identity);
        goLeft.GetComponent<ShockWaveMove>().MoveSpeed = -_shockWaveSpeed;
        goRight.GetComponent<ShockWaveMove>().MoveSpeed = _shockWaveSpeed;
        Destroy(goLeft, 2f);
        Destroy(goRight, 2f);


    }
}
