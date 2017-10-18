using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[CreateAssetMenu(menuName = "Prototype/CharactersActions/Climb")]
public class ClimbAction : _Action
{
    Vector3 m_Move;
    float up;
    float down;
    float movement;

    public override void Execute(CharacterStateController controller)
    {
        Climb(controller);
    }

    private void Climb(CharacterStateController controller)
    {
        // For Animator 
        if (Input.GetAxis("Vertical") != 0)
        {
           movement = Input.GetAxis("Vertical");
        }
        else
        {
            movement = 0;
        }
        
        // For actual movement
        if (Input.GetAxis("Vertical") > 0)
        {
            up = Input.GetAxis("Vertical");
        }
        else
        {
            up = 0;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            down = Input.GetAxis("Vertical");
        }
        else
        {
            down = 0;
        }

        if (!controller.m_CharacterController.climbingTop)
        {
             controller.m_CharacterController.CharacterTansform.Translate(Vector3.up * up * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1
          
        }
        if (!controller.m_CharacterController.climbingBottom)
        {
             controller.m_CharacterController.CharacterTansform.Translate(Vector3.up * down * controller.characterStats.m_ClimbSpeed * Time.deltaTime);//0.0.1
           
        }
        // Animator
        controller.m_CharacterController.m_ForwardAmount = movement;
        //Debug.Log(controller.m_CharacterController.m_ForwardAmount);
    }
}
