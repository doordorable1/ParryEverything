using UnityEngine;


// TODO : 애니메이션 연결 해서 할려고 했지만 뭔지 모르겠으나 걸리는게 있음
// TODO : 망치를 IDLE에 이식 한 후에 해야됨 
public class EventAnimIdle : MonoBehaviour
{
    BossWeapon _bossWeapon;
    

    private void Start() => _bossWeapon = FindAnyObjectByType<BossWeapon>();

    /// <summary>
    /// 망치 킬거
    /// </summary>
    public void OnAnimationEvent()
    {
        _bossWeapon.gameObject.SetActive(true);
    }
    /// <summary>
    /// 망치 끌거
    /// </summary>
    public void OffAnimationEvent()
    {
        _bossWeapon.gameObject.SetActive(false);
    }
}
