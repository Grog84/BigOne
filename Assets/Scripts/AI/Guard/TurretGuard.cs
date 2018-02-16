using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AI
{
    public class TurretGuard : Guard
    {

        public void Shoot()
        {
            m_Animator.SetTrigger("Shoot");
            //StartCoroutine(ShootCO());
            //DefeatPlayer(); // will later be moved to the animator
        }


        IEnumerator ShootCO()
        {
            yield return new WaitForSeconds(1.0f);
            DefeatPlayer();
            yield return null;
        }

    }
}

