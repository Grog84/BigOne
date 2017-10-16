using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[CreateAssetMenu(menuName = "Prototype/CharactersActions/StartPush")]
public class StartPushAction : _Action
{
    

    public override void Execute(CharacterStateController controller)
    {
        StartPush(controller);
    }

    private void StartPush(CharacterStateController controller)
    {

        controller.m_CharacterController.isPushing = true;
        
        // Rotate the player to a straigth direction
        
    }
}

