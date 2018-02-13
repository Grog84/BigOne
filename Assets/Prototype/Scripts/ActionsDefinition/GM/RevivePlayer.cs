using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace GM.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/GM/RevivePlayer")]
    public class RevivePlayer : _Action
    {

        public override void Execute(GMStateController controller)
        {
            Revive(controller);
        }

        private void Revive(GMStateController controller)
        {
            // Debug.Log("Prima");
            Debug.Log((int)controller.m_GM.isCharacterPlaying);
            controller.m_GM.m_CharacterInterfaces[(int)controller.m_GM.isCharacterPlaying].RevivePlayer();
           // Debug.Log("Dopo");
        }
    }
}
