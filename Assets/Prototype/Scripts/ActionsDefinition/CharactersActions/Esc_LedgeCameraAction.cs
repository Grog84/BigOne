using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/Camera/Esc_LedgeCameraAction")]
    public class Esc_LedgeCameraAction : _Action
    {


        public override void Execute(CharacterStateController controller)
        {
            EndCameraLedge(controller);
        }

        private void EndCameraLedge(CharacterStateController controller)
        {
            LedgeCameraScript thisCamera = (LedgeCameraScript)GMController.instance.m_MainCamera[2];
            thisCamera.myCamera.m_Priority = 0;
        }
    }
}
