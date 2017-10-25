using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/GMActions/RevivePlayer")]
    public class RevivePlayer : _Action
    {

        public override void Execute(GMStateController controller)
        {
            Revive(controller);
        }

        private void Revive(GMStateController controller)
        {
            controller.m_GM.m_CharacterInterfaces[(int)controller.m_GM.isCharacterPlaying].RevivePlayer(); ;
        }
    }
}
