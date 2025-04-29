using System;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class ChasePlayer : Action
    {
        public SharedInt chaseSpeed;
        public SharedFloat chaseDistance;

        private Rigidbody2D rb;
        private PlayerMove player;
        private Vector2 movePosition;
        private float speed;

        public override void OnAwake()
        {
            base.OnAwake();
            rb = GetComponent<Rigidbody2D>();
            player = UnityEngine.Object.FindFirstObjectByType<PlayerMove>();
        }

        public override void OnStart()
        {
            base.OnStart();
            speed = 0.001f * chaseSpeed.Value;
            if (rb.transform.position.x < player.transform.position.x) movePosition = Vector2.right * speed;
            else movePosition = Vector2.left * speed;
        }

        public override TaskStatus OnUpdate()
        {
            rb.MovePosition(rb.position + movePosition);

            if (Mathf.Abs(rb.transform.position.x - player.transform.position.x) < chaseDistance.Value)
            {
                return TaskStatus.Success;
            }

            return TaskStatus.Running;
        }
    }
}