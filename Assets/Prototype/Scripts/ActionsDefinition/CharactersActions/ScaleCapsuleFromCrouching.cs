using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/StateExit/ScaleCapsuleFromCrouching")]
public class ScaleCapsuleFromCrouching : _Action {

    public override void Execute(StateController controller)
    {
        ScaleCapsule(controller);
    }


    void ScaleCapsule(StateController controller)
    {

        controller.characterObj.m_Capsule.height = controller.characterObj.m_Capsule.height * 2f;
        controller.characterObj.m_Capsule.center = controller.characterObj.m_Capsule.center * 2f;

    }
}
