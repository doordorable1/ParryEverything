using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP
    {
        get
        {
            return _hp;

        }
        set 
        {
            _hp = value;
            DestoryObj(_hp);
        }
    }
    public bool IsDead { get { return _dead; }  }

    int _hp = 2;
    bool _dead = false;

    void DestoryObj(int hp)
    {
        // TODO :죽는 애니 실행 시키기
        // 애니메이션 다끝난후에 Destroy
        if (hp <= 0 && _dead == false)
        {
            _dead = true;

            //TODO: Animation -> Event에 Destory 넣기 
            //TODO: Animation 실행 이 끝난후에 Destroy 처리 
            Destroy(gameObject,5);
        }
    }    
        
}
