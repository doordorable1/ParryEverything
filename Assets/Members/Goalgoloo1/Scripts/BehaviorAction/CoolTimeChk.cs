using System.Collections;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CoolTimeChk : Action
{
    public float duration = 7f;

    private bool canStart = true;


    public override TaskStatus OnUpdate()
    {
        if (canStart == true)
        {
            canStart = false;
            StartCoroutine(CoolTime());
            return TaskStatus.Success;
        }
        return TaskStatus.Failure;
    }

    public override void OnEnd()
    {

    }
    

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(duration);
        canStart = true;
    }


}
