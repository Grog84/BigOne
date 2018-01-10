namespace AI.BT
{
    public class ActionPedestrianDefeatPlayer : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Pedestrian>().DefeatPlayer();
            return TaskState.SUCCESS;
        }
    }
}