using UnityEngine;

namespace AI.BT
{
    public class ActionDefeatPlayer : Task
    {
        public override TaskState Run()
        {
            Debug.Log("DefeatPlayer");
            GMController.instance.SetBkgMusicState(101f);
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().DefeatPlayer();
            return TaskState.SUCCESS;
        }
    }
}