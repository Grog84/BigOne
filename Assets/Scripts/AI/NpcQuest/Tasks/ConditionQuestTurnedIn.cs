using UnityEngine;

namespace AI.BT
{
    public class ConditionQuestTurnedIn : Task
    {
        public override TaskState Run()
        {

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("questFinisherCompleted"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}