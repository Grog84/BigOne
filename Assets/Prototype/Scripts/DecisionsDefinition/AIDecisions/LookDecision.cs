using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/AI/Look")]
    public class LookDecision : Decision
    {

        public override bool Decide(EnemiesAIStateController controller)
        {
            bool targetVisible = Look(controller);
            return targetVisible;
        }

        private bool Look(EnemiesAIStateController controller)
        {
            //RaycastHit hit;

            //Debug.DrawRay(controller.m_AgentController.eyes.position, controller.m_AgentController.eyes.forward.normalized * controller.m_AgentController.agentStats.lookRange, Color.green);

            ////condizoine per il fov
            //if (Physics.SphereCast(controller.m_AgentController.eyes.position, controller.m_AgentController.agentStats.lookSphereCastRadius, controller.m_AgentController.eyes.forward, out hit, controller.m_AgentController.agentStats.lookRange)
            //    && hit.collider.CompareTag("Player"))
            //{
            //    controller.m_AgentController.chaseTarget = hit.transform;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return true;
        }
    }
}
