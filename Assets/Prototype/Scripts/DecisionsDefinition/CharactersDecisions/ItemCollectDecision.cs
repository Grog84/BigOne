using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ItemCollectDecision")]
    public class ItemCollectDecision : Decision
    {
        public override bool Decide(CharacterStateController controller)
        {
            bool isInteracting = CheckIfItemCollect(controller);
            return isInteracting;
        }

        private bool CheckIfItemCollect(CharacterStateController controller)
        {
            if (controller.m_CharacterController.isInItemArea && !controller.m_CharacterController.isPushDirectionRight &&
                !controller.m_CharacterController.isDoorDirectionRight && Input.GetButtonDown("Interact") && controller.m_CharacterController.isItemCREnd)
            {
                if(controller.m_CharacterController.ItemCollider.GetComponent<ManipulateStateTrigger>() 
                    && controller.m_CharacterController.ItemCollider.GetComponent<ManipulateStateTrigger>().questProgress != GMController.instance.questManager.actualQuest)
                {
                    Debug.Log("ora non posso raccoglierlo");
                    return false;
                }
                else
                {
                    Debug.Log("ora l'ho raccolto");
                    return true;
                }
            }
            else
            {
                Debug.Log("che schifo raccogliere le cose");
                return false;
            }

        }


    }
}
