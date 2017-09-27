using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/GroundCheck")]
public class GroundCheckDecision : Decision {

    public override bool Decide(StateController controller)
    {
        bool isOnTheGround = CheckIsOnGround(controller);
        return isOnTheGround;
    }

    private bool CheckIsOnGround(StateController controller)
    {
        RaycastHit hitInfo;
        #if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(controller.characterObj.CharacterTansform.position + (Vector3.up * 0.1f),
            controller.characterObj.CharacterTansform.position + (Vector3.up * 0.1f) + (Vector3.down * controller.characterStats.m_GroundCheckDistance));
        #endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(controller.characterObj.CharacterTansform.position + (Vector3.up * 0.1f), Vector3.down,
            out hitInfo, controller.characterStats.m_GroundCheckDistance))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
		
}
