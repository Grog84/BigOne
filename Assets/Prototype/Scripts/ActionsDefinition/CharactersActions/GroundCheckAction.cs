using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckAction : _Action {

    [SerializeField] float m_GroundCheckDistance = 0.1f;

    public override void Execute(StateController controller)
    {
        CheckGroundStatus(controller);
    }

    void CheckGroundStatus(StateController controller)
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        // helper to visualise the ground check ray in the scene view
        Debug.DrawLine(controller.characterObj.CharacterTansform.position + (Vector3.up * 0.1f),
            controller.characterObj.CharacterTansform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
#endif
        // 0.1f is a small offset to start the ray from inside the character
        // it is also good to note that the transform position in the sample assets is at the base of the character
        //if (Physics.Raycast(controller.characterObj.CharacterTansform.transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, m_GroundCheckDistance))
        //{
        //    m_GroundNormal = hitInfo.normal;
        //    m_IsGrounded = true;
        //    m_Animator.applyRootMotion = true;
        //}
        //else
        //{
        //    m_IsGrounded = false;
        //    m_GroundNormal = Vector3.up;
        //    m_Animator.applyRootMotion = false;
        //}
    }

}
