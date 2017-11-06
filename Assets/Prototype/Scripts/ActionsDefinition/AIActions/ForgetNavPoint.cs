using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace AI.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/AI/Guard/ForgetNavPoint")]
    public class ForgetNavPoint : _Action
    {
        public override void Execute(EnemiesAIStateController controller)
        {
            Forget(controller);
        }

        private void Forget(EnemiesAIStateController controller)
        {
            controller.m_AgentController.m_NavMeshAgent.destination = controller.transform.position;
        }
    }
}
