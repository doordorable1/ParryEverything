using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class CooldownReverse : Decorator
    {
        public SharedFloat duration = 2;

        // The status of the child after it has finished running.
        private TaskStatus executionStatus = TaskStatus.Inactive;
        private float cooldownTime = -1;

        public override bool CanExecute()
        {
            if (cooldownTime == -1)
            {
                return true;
            }

            return cooldownTime + duration.Value > Time.time;
        }

        public override int CurrentChildIndex()
        {
            if (cooldownTime == -1)
            {
                return 0;
            }
            return -1;
        }

        public override void OnChildExecuted(TaskStatus childStatus)
        {
            executionStatus = childStatus;
            if (executionStatus == TaskStatus.Failure || executionStatus == TaskStatus.Success)
            {
                cooldownTime = Time.time;
            }
        }

        public override TaskStatus OverrideStatus()
        {
            if (!CanExecute())
            {
                return TaskStatus.Failure;
            }
            return executionStatus;
        }

        public override TaskStatus OverrideStatus(TaskStatus status)
        {
            if (status == TaskStatus.Running)
            {
                return status;
            }
            return executionStatus;
        }



        public override void OnEnd()
        {
            executionStatus = TaskStatus.Inactive;
            cooldownTime = -1;
        }
    }
}