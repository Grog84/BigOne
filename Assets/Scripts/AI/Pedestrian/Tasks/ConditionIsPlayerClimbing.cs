namespace AI.BT
{
    public class ConditionIsPlayerClimbing : Task
    {
        Pedestrian pedestrian;
        public override TaskState Run()
        {
            pedestrian = (Pedestrian)m_BehaviourTree.m_Blackboard.m_Agent;
            pedestrian.CheckPlayerClimbing();

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerIsClimbing"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}