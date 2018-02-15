namespace AI
{
    public class TurretGuard : Guard
    {

        public void Shoot()
        {
            m_Animator.SetTrigger("Shoot");
            //DefeatPlayer(); // will later be moved to the animator
        }



    }
}

