namespace AI.BT
{
    public class ConditionQuestTurnedIn : Task
    {
        public override TaskState Run()
        {
            if(m_BehaviourTree.m_Blackboard.GetBoolValue("questTurnInStatus"))
                return TaskState.SUCCESS;
            else
                return TaskState.FAILURE;
        }
    }
}