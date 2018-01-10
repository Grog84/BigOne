namespace AI.BT
{
    public class ConditionPedestrianPlayerInRange : Task
    {
        Pedestrian pedestrian;
        public override TaskState Run()
        {
            pedestrian = (Pedestrian)m_BehaviourTree.m_Blackboard.m_Agent;
            pedestrian.CheckPlayerDistance();

            if (m_BehaviourTree.m_Blackboard.GetBoolValue("PlayerInRange"))
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}