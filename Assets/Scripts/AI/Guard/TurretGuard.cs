using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AI
{
    public class TurretGuard : Guard
    {
        public override void GetAlarmed()
        {
            perceptionPercentage = 100;

            m_State = GuardState.ALARMED;
            SetBlackboardValue("GuardState", (int)GuardState.ALARMED);
            LoadStats(alarmedStats);
            guardAllert.SetActive(false);
            SetBlackboardValue("IsRelaxing", true);

            statusColor = Color.red;
        }

        public override void GetCurious()
        {
            base.GetCurious();
            SetBlackboardValue("IsRelaxing", true);
        }

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

