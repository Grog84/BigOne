using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/GroundCheck")]
public class GroundCheckDecision : Decision
{

    public override bool Decide(CharacterStateController controller)
    {
        bool isOnTheGround = CheckIsOnGround(controller);
        return isOnTheGround;
    }

    private bool CheckIsOnGround(CharacterStateController controller)
    {
        RaycastHit hitInfo;
        #if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(controller.m_CharacterController.CharacterTansform.position, 
                        controller.m_CharacterController.CharacterTansform.position + (Vector3.down * controller.characterStats.m_GroundCheckDistance),Color.green);
        #endif
        // ray_lenght is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.position, (Vector3.down * controller.m_CharacterController.ray_length),
            out hitInfo, controller.characterStats.m_GroundCheckDistance))
        {
            controller.m_CharacterController.floorNoiseMultiplier = hitInfo.transform.GetComponent<Floor>().GetNoiseMultiplier();
            return true;
        }
        else
        {
            return false;
        }
    }
    
		
}
