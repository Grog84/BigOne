﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Prototype/CharactersActions/Push")]
public class PushAction : _Action
{
    //Vector3 m_Move;
    float forward;
    float backward;

    public override void Execute(CharacterStateController controller)
    {
        Push(controller);
    }

    private void Push(CharacterStateController controller)
    {
        RaycastHit hit;

        if (Physics.Raycast(controller.m_CharacterController.CharacterTansform.Find(controller.m_CharacterController.pushableName).position + Vector3.up * controller.m_CharacterController.m_CharController.bounds.size.y / 2.0f, controller.m_CharacterController.CharacterTansform.forward, out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromPushableObstacle))//, LayerMask.NameToLayer("Pushable")))
        {
            Debug.DrawRay(controller.m_CharacterController.CharacterTansform.Find(controller.m_CharacterController.pushableName).position + Vector3.up * controller.m_CharacterController.m_CharController.bounds.size.y / 2.0f, controller.m_CharacterController.CharacterTansform.forward, Color.red);
            

            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Default") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Climbable") ||
                      hit.transform.gameObject.layer == LayerMask.NameToLayer("Doors"))
            {
                Debug.Log("vedo ostacolo");
                controller.m_CharacterController.isPushLimit = true;
                Debug.Log(controller.m_CharacterController.isPushLimit);
            }
           
        }
        else
        {
            controller.m_CharacterController.isPushLimit = false;
            Debug.Log(controller.m_CharacterController.isPushLimit);
        }

        if (Input.GetKey(KeyCode.W))
        {
            forward = Input.GetAxis("Vertical");
        }
        else
        {
            forward = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            backward = Input.GetAxis("Vertical");
        }
        else
        {
            backward = 0;
        }

        if (controller.m_CharacterController.isPushLimit)
        {
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1          
        }
        else if(!controller.m_CharacterController.isPushLimit)
        {
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * forward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
            controller.m_CharacterController.CharacterTansform.Translate(Vector3.forward * backward * controller.characterStats.m_PushSpeed * Time.deltaTime);//0.0.1
        }
    }
}

