using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Crouch")]
public class CrouchAction : _Action {

    private Vector3 m_CamForward;             // The current forward direction of the camera
    private Vector3 m_Move;
    private Vector3 m_GroundNormal;
    private float m_TurnAmount;
    private float m_ForwardAmount;

    public override void Execute(StateController controller)
    {
        Crouch(controller);
    }

    private void Crouch(StateController controller)
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        // calculate move direction to pass to character
        if (controller.characterObj.m_Camera != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(controller.characterObj.m_Camera.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = v * m_CamForward + h * controller.characterObj.m_Camera.right;
        }
        else
        {
            // we use world-relative directions in the case of no main camera
            m_Move = v * Vector3.forward + h * Vector3.right;
        }

        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (m_Move.magnitude > 1f) m_Move.Normalize();
        m_Move = controller.characterObj.CharacterTansform.InverseTransformDirection(m_Move);
        m_Move = Vector3.ProjectOnPlane(m_Move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
        m_ForwardAmount = m_Move.z;
    }

    public void Move(Vector3 move, StateController controller)
    {

        // convert the world relative moveInput vector into a local-relative
        // turn amount and forward amount required to head in the desired
        // direction.
        if (move.magnitude > 1f) move.Normalize();
        move = controller.characterObj.CharacterTansform.InverseTransformDirection(move);
        move = Vector3.ProjectOnPlane(move, m_GroundNormal);
        m_TurnAmount = Mathf.Atan2(move.x, move.z);
        m_ForwardAmount = move.z;

        ApplyExtraTurnRotation(controller);
        //ScaleCapsuleForCrouching(crouch);

    }

    void ApplyExtraTurnRotation(StateController controller)
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(controller.characterStats.m_StationaryTurnSpeed,
            controller.characterStats.m_MovingTurnSpeed, m_ForwardAmount);
        controller.characterObj.CharacterTansform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }

    // Questo va messo come uscita dalla stato in piedi quando si entra in stato crouch. Bisogna inserire nello stato una generica azione di inizio
    //void ScaleCapsuleForCrouching(bool crouch)
    //{
    //    if (crouch)
    //    {
    //        if (m_Crouching) return;
    //        m_Capsule.height = m_Capsule.height / 2f;
    //        m_Capsule.center = m_Capsule.center / 2f;
    //        m_Crouching = true;
    //    }
    //    else
    //    {
    //        Ray crouchRay = new Ray(m_Rigidbody.position + Vector3.up * m_Capsule.radius * k_Half, Vector3.up);
    //        float crouchRayLength = m_CapsuleHeight - m_Capsule.radius * k_Half;
    //        if (Physics.SphereCast(crouchRay, m_Capsule.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
    //        {
    //            m_Crouching = true;
    //            return;
    //        }
    //        m_Capsule.height = m_CapsuleHeight;
    //        m_Capsule.center = m_CapsuleCenter;
    //        m_Crouching = crouch;
    //    }
    //}
}
