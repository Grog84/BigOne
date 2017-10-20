using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using DG.Tweening;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/ItemCollectAction")]
public class ItemCollectAction : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        Interact(controller);
    }

    private void Interact(CharacterStateController controller)
    {
      
            // Pick up Keys
            if (controller.m_CharacterController.isInKeyArea)
            {
                controller.m_CharacterController.Keychain.Add(controller.m_CharacterController.KeyCollider.gameObject);
                controller.m_CharacterController.KeyCollider.gameObject.SetActive(false);
                controller.m_CharacterController.isInKeyArea = false;
            }

     
    }
}
