namespace AI.BT
{
    public class ActionShootPlayer : Task
    {
        public override TaskState Run()
        {
            m_BehaviourTree.m_Blackboard.m_Agent.GetComponent<TurretGuard>().Shoot();
            GMController.instance.SetBkgMusicState(101f);
            return TaskState.SUCCESS;
        }
    }
}