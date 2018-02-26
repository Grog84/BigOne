namespace AI.BT
{
    public class ConditionNavPointTimerNoZero : Task
    {
        public override TaskState Run()
        {

            if(m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<Guard>().GetNavPointSecWaiting() == 0)
                return TaskState.FAILURE;
            
            return TaskState.SUCCESS;

            
        }
    }
}