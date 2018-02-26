namespace AI.BT
{
    public class ActionStay : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().Stay();
            return TaskState.SUCCESS;
        }
    }
}