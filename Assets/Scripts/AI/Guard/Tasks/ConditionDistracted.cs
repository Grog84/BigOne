namespace AI.BT
{
    public class ConditionDistracted : Task
    {
        public override TaskState Run()
        {
            if (m_BehaviourTree.m_Blackboard.GetIntValue("GuardState") == (int)GuardState.DISTRACTED)
            {
                return TaskState.SUCCESS;
            }
            else
                return TaskState.FAILURE;
        }
    }
}