using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionCurrentQuestFinisher : Task
    {
        public override TaskState Run()
        {

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("questFinisherActive")==true)
            {

                //m_BehaviourTree.m_Blackboard.SetBoolValue("nextQuestActive", true);
                //m_BehaviourTree.m_Blackboard.SetBoolValue("questFinsherActive", false);
                //m_BehaviourTree.m_Blackboard.SetBoolValue("questFinsherCompleted", true);
                return TaskState.SUCCESS;
            }
            else
            {
                Debug.Log("ENTERD");
                return TaskState.FAILURE;
            }
        }
    }
}