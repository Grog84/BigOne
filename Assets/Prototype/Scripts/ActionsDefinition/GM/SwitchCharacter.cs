using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/GMActions/SwitchCharacter")]
    public class SwitchCharacter : _Action {

        public override void Execute(GMStateController controller)
        {
            Switch(controller);
        }

        private void Switch(GMStateController controller)
        {
            if (Input.GetKeyDown(KeyCode.Tab) && GMController.instance.canSwitch == true)
            {
                if (controller.m_GM.isCharacterPlaying == CharacterActive.Boy)
                {
                    controller.m_GM.isCharacterPlaying = CharacterActive.Mother;
                }
                else
                {
                    controller.m_GM.isCharacterPlaying = CharacterActive.Boy;
                }
                GMController.instance.canSwitch = false;
            }
        }
    }
}
