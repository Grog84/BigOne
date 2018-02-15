namespace AI
{
    public class TurretGuard : Guard
    {

        public void Shoot()
        {
            m_Animator.SetBool("Shoot", true);
            DefeatPlayer(); // will later be moved to the animator
        }



    }
}

