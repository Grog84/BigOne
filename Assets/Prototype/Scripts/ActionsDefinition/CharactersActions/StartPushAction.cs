﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/StartPush")]
    public class StartPushAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            StartPush(controller);
        }

        private void StartPush(CharacterStateController controller)
        {
            controller.m_CharacterController.pushObject = controller.m_CharacterController.pushCollider.transform.parent.gameObject;
            controller.m_CharacterController.isPushing = true;

        }
    }
}
