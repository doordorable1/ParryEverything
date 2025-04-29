using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class WaitForAnimation : Action // 애니메이션이 끝날 때까지 대기
    {
        private AnimationEventReceiver eventReceiver;
        private bool isDone;
        public SharedBool isAttackingGlobal; 


        public override void OnAwake()
        {
            base.OnAwake();
            eventReceiver = GetComponent<AnimationEventReceiver>();
        }

        public override void OnStart()
        {
            base.OnAwake();
            isDone = false;
            isAttackingGlobal.Value = true;
            eventReceiver.OnAnimationDone += AnimationDone;
            
        }

        public override TaskStatus OnUpdate()
        {
            return isDone ? TaskStatus.Success : TaskStatus.Running;
        }

        public override void OnEnd()
        {
            base.OnEnd();
            eventReceiver.OnAnimationDone -= AnimationDone;
            isDone = false;
            isAttackingGlobal.Value = false;

        }

        private void AnimationDone()
        {
            isDone = true;
        }
    }
}