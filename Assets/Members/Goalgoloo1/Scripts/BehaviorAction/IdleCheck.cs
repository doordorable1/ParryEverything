using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
using BehaviorDesigner.Runtime;

public class IdleCheck : Action
{
    //public Transform[] targets;
    //public string targetTag;
    //public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Success;
    }
}
