using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class FacePlayer : Action
{
    float baseScaleX;
    PlayerMove player;

    public override void OnAwake()
    {
        base.OnAwake();
        baseScaleX = transform.localScale.x;
        player = Object.FindFirstObjectByType<PlayerMove>();

    }

    public override TaskStatus OnUpdate()
    {
        Vector3 scale = this.transform.localScale;
        scale.x = this.transform.position.x > player.transform.position.x ? -baseScaleX : baseScaleX;
        this.transform.localScale = scale;

        

        return TaskStatus.Success;


    }
}
