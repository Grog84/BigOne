using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using DG.Tweening;
using StateMachine;
using QuestManager;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ItemCollectAction")]
    public class ItemCollectAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            Interact(controller);
        }

        private void Interact(CharacterStateController controller)
        {

            // Pick up Keys
            if (GMController.instance.isCharacterPlaying == CharacterActive.Mother && controller.m_CharacterController.ItemCollider.tag == "Key")
            {
                if (controller.m_CharacterController.ItemCollider.transform.GetComponent<QuestObject>() != null)
                {
                    //controller.m_CharacterController.ItemCollider.transform.parent.GetComponent<QuestObject>().Picked = true;
                    controller.m_CharacterController.ItemCollider.transform.GetComponent<QuestObject>().CompleteQuest();
                }
                controller.m_CharacterController.startItemAnimation = true;
                controller.m_CharacterController.Keychain.Add(controller.m_CharacterController.ItemCollider.gameObject);
                controller.m_CharacterController.ItemCollider.GetComponent<Keys>().PickUp();
                controller.m_CharacterController.ItemCollider.gameObject.SetActive(false);
                controller.m_CharacterController.isInItemArea = false;
            }
            else if (controller.m_CharacterController.ItemCollider.tag != "Key")
            {
                if(controller.m_CharacterController.ItemCollider.transform.GetComponent<QuestObject>() != null)
                {
                    //controller.m_CharacterController.ItemCollider.transform.parent.GetComponent<QuestObject>().Picked = true;
                    controller.m_CharacterController.ItemCollider.transform.GetComponent<QuestObject>().CompleteQuest();
                }
                controller.m_CharacterController.startItemAnimation = true;
                controller.m_CharacterController.Keychain.Add(controller.m_CharacterController.ItemCollider.gameObject);
                controller.m_CharacterController.ItemCollider.gameObject.SetActive(false);
                controller.m_CharacterController.isInItemArea = false;
            }
        }
    }
}
