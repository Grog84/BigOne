using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Walk")]
public class WalkAction : _Action
{
    Vector3 m_Move;
    Vector3 m_CamForward;

    public override void Execute(CharacterStateController controller)
    {
        Walk(controller);
    }

    private void Walk(CharacterStateController controller)
    {
        //float get from the axis used in the vector3 m_Move
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //used in the Move method of the Character Controller
        //m_Move = new Vector3(h, 0, v);

        //calculate move direction to pass to character
        if (controller.m_CharacterController.m_Camera != null)
        {
            // calculate camera relative direction to move:
            m_CamForward = Vector3.Scale(controller.m_CharacterController.m_Camera.forward, new Vector3(1, 0, 1)).normalized;
            m_Move = (v * m_CamForward + h * controller.m_CharacterController.m_Camera.right);
        }
        
        m_Move *= controller.characterStats.m_WalkSpeed;
        Mathf.Clamp(m_Move.x + m_Move.z, 0, 1);

        Debug.Log(m_Move);
        //make the model face the camera direction
        if (m_Move != Vector3.zero)
            controller.m_CharacterController.CharacterTansform.forward = m_Move;
        
        controller.m_CharacterController.m_CharController.Move(m_Move * Time.deltaTime);
    }
}
