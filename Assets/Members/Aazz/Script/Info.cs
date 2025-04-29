using System.Collections.Generic;
using UnityEngine;


public enum Filter { Unit, ActObj }

public class Info : MonoBehaviour
{
    public int team;
    public float multiply=1;
    [Space(30)]



    public List<Act> acts = new(); //
    public List<GameObject> now = new(); //진행중인 act 
    [Space(30)]



    //1차 2차 생성물
    public GameObject owner;
    public GameObject target;
    public Vector3 to;
    public Act act;


    private void Start()
    {
        for (int i = 0; i < acts.Count; i++)
        {
            acts.Add(Instantiate(acts[i], transform));
        }
    }
    public void Init(GameObject _owner, Vector3 _to, GameObject _target, Act _act)
    {
        if (_owner)
        {
            var v = _owner.GetComponent<Info>();
            team = v.team;
            multiply = v.multiply;
        }


        owner = _owner;
        to = _to;
        target = _target;
        act = _act;
    }

    public static bool isDiffer(GameObject t1, GameObject t2)
    {
        var v1 = t1.GetComponentInParent<Info>();
        var v2 = t2.GetComponentInParent<Info>();

        if (v1 == null || v2 == null) 
            return false;

        if (v1.team == v2.team)
            return false;

        return true;
    }
}
