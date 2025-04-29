using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    public class WeightedRandomSelector : Composite // 가중치에 따라 노드 선택
    {
        public List<SharedInt> weights = new();

        private int selectedChild = -1;
        private TaskStatus executionStatus = TaskStatus.Inactive;

        public override void OnStart()
        {
            selectedChild = -1;

            int totalWeight = 0;
            foreach (SharedInt w in weights) totalWeight += w.Value;

            int randomValue = Random.Range(0, totalWeight);
            int cumulativeValue = 0;

            for(int i = 0; i < weights.Count; i++)
            {
                cumulativeValue += weights[i].Value;
                if (randomValue <= cumulativeValue)
                {
                    selectedChild = i;
                    break;
                }
            }

            if (selectedChild == -1)
            {
                Debug.Log("WeightedRandomSelector Parameter Wrong");
                selectedChild = 0;
            }
        }

        public override int CurrentChildIndex()
        {
            return selectedChild;
        }

        public override bool CanExecute()
        {
            return selectedChild != -1 && executionStatus != TaskStatus.Success && executionStatus != TaskStatus.Failure;
        }

        public override void OnChildExecuted(TaskStatus childStatus)
        {
            executionStatus = childStatus;
        }

        public override void OnEnd()
        {
            selectedChild = -1;
            executionStatus = TaskStatus.Inactive;
        }
    }

}
