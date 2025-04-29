using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class WhirlWind : Action
    {
        public SharedInt whirlWindMaxSpeed;
        public SharedInt whirlWindDurationFrame;

        private Animator animator;
        private int nowFrame;
        private Rigidbody2D rb;
        private PlayerMove player;
        private Vector2 movePosition;
        private float speed;

        public override void OnAwake()
        {
            base.OnAwake();
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody2D>();
            player = UnityEngine.Object.FindFirstObjectByType<PlayerMove>();
        }

        public override void OnStart()
        {
            base.OnStart();
            nowFrame = 0;
            speed = 0.001f * whirlWindMaxSpeed.Value;
            if (rb.transform.position.x < player.transform.position.x) movePosition = Vector2.right * speed;
            else movePosition = Vector2.left * speed;
        }

        public override TaskStatus OnUpdate()
        {
            float cof = -4 * whirlWindMaxSpeed.Value / whirlWindDurationFrame.Value / whirlWindDurationFrame.Value * nowFrame + 4 * whirlWindMaxSpeed.Value / whirlWindDurationFrame.Value * nowFrame;

            rb.MovePosition(rb.position + movePosition * cof); // whirlWindDurationFrame프레임동안 진행되고 최대속력이 whirlWindMaxSpeed인 포물선

            if (nowFrame<whirlWindDurationFrame.Value)
            {
                nowFrame++;
                return TaskStatus.Running;
            }
            else
            {
                return TaskStatus.Success;
            }
        }
    }
}