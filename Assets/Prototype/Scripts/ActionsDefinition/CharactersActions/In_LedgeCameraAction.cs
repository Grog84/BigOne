using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Camera/In_LedgeCameraAction")]
    public class In_LedgeCameraAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            StartCameraLedge(controller);
        }

        private void StartCameraLedge(CharacterStateController controller)
        {
            LedgeCameraScript thisCamera = (LedgeCameraScript)GMController.instance.m_MainCamera[2];
            thisCamera.myCamera.m_Priority = 150;
        }
    }
}
