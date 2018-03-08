using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/ShowBag")] 
    public class ShowBag : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            ShowCarryingItem(controller);
        }

        public void ShowCarryingItem(CharacterStateController controller)
        {
            controller.m_CharacterController.bag.SetActive(true);
        }

    }
}
