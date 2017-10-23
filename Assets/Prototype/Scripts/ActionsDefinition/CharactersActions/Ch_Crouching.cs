using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/CharactersActions/Crouching")]
    public class Ch_Crouching : _Action
    {
        public override void Execute(CharacterStateController controller)
        {
            Crouching(controller);
        }

        public void Crouching (CharacterStateController controller)
        {
            controller.characterStats.m_MovementSpeed = controller.characterStats.m_CrouchSpeed;
        }
    }
}
