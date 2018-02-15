using UnityEngine;

namespace AI.BT
{
    public class ActionDefeatPlayer : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().DefeatPlayer();
            GMController.instance.SetBkgMusicState(101f);
            return TaskState.SUCCESS;
        }
    }
}