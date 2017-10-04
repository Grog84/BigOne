using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Walk")]
public class WalkAction : _Action
{
    Vector3 m_Move;

    public override void Execute(CharacterStateController controller)
    {
        Walk(controller);
    }

    private void Walk(CharacterStateController controller)
    {
        m_Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.characterObj.m_CharController.Move(m_Move * Time.deltaTime * controller.characterStats.m_WalkSpeed);
        if (m_Move != Vector3.zero)
            controller.characterObj.CharacterTansform.forward = m_Move;

        //controller.characterObj.CharacterTansform.Rotate(0, Input.GetAxis("Horizontal") * controller.characterStats.m_RotateSpeed, 0);
        //Vector3 forward = controller.characterObj.CharacterTansform.TransformDirection(Vector3.forward);
        //float curSpeed = controller.characterStats.m_Speed * Input.GetAxis("Vertical");
        //controller.characterObj.m_CharController.SimpleMove(forward * curSpeed);

    }


    //private void Walk(StateController controller)
    //{
    //    float h = CrossPlatformInputManager.GetAxis("Horizontal");
    //    float v = CrossPlatformInputManager.GetAxis("Vertical");

    //    // calculate move direction to pass to character
    //    if (controller.characterObj.m_Camera != null)
    //    {
    //        // calculate camera relative direction to move:
    //        m_CamForward = Vector3.Scale(controller.characterObj.m_Camera.forward, new Vector3(1, 0, 1)).normalized;
    //        m_Move = v * m_CamForward + h * controller.characterObj.m_Camera.right;
    //    }
    //    else
    //    {
    //        // we use world-relative directions in the case of no main camera
    //        m_Move = v * Vector3.forward + h * Vector3.right;
    //    }

    //    // convert the world relative moveInput vector into a local-relative
    //    // turn amount and forward amount required to head in the desired
    //    // direction.
    //    if (m_Move.magnitude > 1f) m_Move.Normalize();
    //    m_Move = controller.characterObj.CharacterTansform.InverseTransformDirection(m_Move);
    //    m_Move = Vector3.ProjectOnPlane(m_Move, m_GroundNormal);
    //    controller.m_CharacterController.m_TurnAmount = Mathf.Atan2(m_Move.x, m_Move.z);
    //    controller.m_CharacterController.m_ForwardAmount = m_Move.z;
    //}

    //public void Move(Vector3 move, StateController controller)
    //{

    //    // convert the world relative moveInput vector into a local-relative
    //    // turn amount and forward amount required to head in the desired
    //    // direction.
    //    if (move.magnitude > 1f) move.Normalize();
    //    move = controller.characterObj.CharacterTansform.InverseTransformDirection(move);
    //    move = Vector3.ProjectOnPlane(move, m_GroundNormal);
    //    controller.m_CharacterController.m_TurnAmount = Mathf.Atan2(move.x, move.z);
    //    controller.m_CharacterController.m_ForwardAmount = move.z;

    //    ApplyExtraTurnRotation(controller);    

    //}

    //void ApplyExtraTurnRotation(StateController controller)
    //{
    //    // help the character turn faster (this is in addition to root rotation in the animation)
    //    float turnSpeed = Mathf.Lerp(controller.characterStats.m_StationaryTurnSpeed,
    //        controller.characterStats.m_MovingTurnSpeed, controller.m_CharacterController.m_ForwardAmount);
    //    controller.characterObj.CharacterTansform.Rotate(0, controller.m_CharacterController.m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    //}

}
