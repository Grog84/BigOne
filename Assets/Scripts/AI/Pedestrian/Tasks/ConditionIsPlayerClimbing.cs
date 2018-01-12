namespace AI.BT
{
    public class ConditionIsPlayerClimbing : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Pedestrian>().CheckPlayerClimbing();

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerIsClimbing"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}