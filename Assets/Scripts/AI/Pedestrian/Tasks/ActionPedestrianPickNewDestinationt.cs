namespace AI.BT
{
    public class ActionPedestrianPickNewDestinationt : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Pedestrian>().PickNewDestination();
            return TaskState.SUCCESS;
        }
    }
}