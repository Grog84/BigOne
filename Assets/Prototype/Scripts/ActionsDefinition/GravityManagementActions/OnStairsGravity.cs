using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/OnStairsGravity")]
public class OnStairsGravity : _Action
{
    public override void Execute(CharacterStateController controller)
    {
        onStairsGravity(controller);
    }

    public void onStairsGravity(CharacterStateController controller)
    {
        controller.characterStats.m_Gravity = controller.characterStats.m_StairsGravity;
    }
}	
