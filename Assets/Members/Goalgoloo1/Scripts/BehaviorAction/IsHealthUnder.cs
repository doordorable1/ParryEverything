using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsHealthUnder : Conditional
{
    public SharedInt HealthTreshold;
    public SharedInt CurrentHealth;

    public override TaskStatus OnUpdate()
    {
        return CurrentHealth.Value < HealthTreshold.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}
