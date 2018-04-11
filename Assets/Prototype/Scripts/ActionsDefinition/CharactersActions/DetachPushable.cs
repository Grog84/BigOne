using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/DetachPushable")]
    public class DetachPushable : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            DetachChild(controller);
        }

        private void DetachChild(CharacterStateController controller)
        {
           if(controller.m_CharacterController.isDefeated)
           {
                Debug.Log("isDefeated "+controller.m_CharacterController.isDefeated);
                controller.m_CharacterController.pushObject.transform.parent = null;                       
                controller.m_CharacterController.pushObject.GetComponent<Rigidbody>().isKinematic = true;
           }
        }
    }

}
