using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/StateExit/ScaleCapsuleFromCrouching")]
public class ScaleCapsuleToOrigSize : _Action
{

    public override void Execute(CharacterStateController controller)
    {
        ScaleCapsule(controller);
    }


    void ScaleCapsule(CharacterStateController controller)
    {

        controller.characterObj.m_Capsule.height = controller.characterObj.m_Capsule.height * 2f;
        controller.characterObj.m_Capsule.center = controller.characterObj.m_Capsule.center * 2f;

    }
}
