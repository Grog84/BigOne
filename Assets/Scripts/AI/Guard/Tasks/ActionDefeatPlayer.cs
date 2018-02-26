using UnityEngine;

namespace AI.BT
{
    public class ActionDefeatPlayer : Task
    {
        public override TaskState Run()
        {
            GMController.instance.SetBkgMusicState(101f);
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().DefeatPlayer();
            return TaskState.SUCCESS;
        }
    }
}