using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using DG.Tweening;
using StateMachine;

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
            if (GMController.instance.isCharacterPlaying == CharacterActive.Mother && controller.m_CharacterController.KeyCollider.tag == "Key")
            {
                controller.m_CharacterController.startItemAnimation = true;
                controller.m_CharacterController.Keychain.Add(controller.m_CharacterController.KeyCollider.gameObject);
                controller.m_CharacterController.KeyCollider.gameObject.SetActive(false);
                controller.m_CharacterController.isInKeyArea = false;
            }
            else if (controller.m_CharacterController.KeyCollider.tag != "Key")
            {
                controller.m_CharacterController.startItemAnimation = true;
                controller.m_CharacterController.Keychain.Add(controller.m_CharacterController.KeyCollider.gameObject);
                controller.m_CharacterController.KeyCollider.gameObject.SetActive(false);
                controller.m_CharacterController.isInKeyArea = false;
            }

        }
    }
}
