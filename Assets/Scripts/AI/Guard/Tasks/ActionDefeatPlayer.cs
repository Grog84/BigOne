using UnityEngine;

namespace AI.BT
{
    public class ActionDefeatPlayer : Task
    {
        public override TaskState Run()
        {
            Debug.Log("Defeat Player");
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().DefeatPlayer();
            return TaskState.SUCCESS;
        }
    }
}