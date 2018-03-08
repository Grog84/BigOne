using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/HideBag")] 
    public class HideBag : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            HideCarryingItem(controller);
        }

        public void HideCarryingItem(CharacterStateController controller)
        {
            controller.m_CharacterController.bag.SetActive(false);
        }

    }
}
