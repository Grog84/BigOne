using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/OnStairs")]
public class OnStairsDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isOnStairs = CheckIsOnStairs(controller);
        return isOnStairs;

        

    }

    private bool CheckIsOnStairs(CharacterStateController controller)
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(controller.m_CharacterController.CharacterTansform.position, Vector3.down);
        Physics.Raycast(ray, out hitInfo, 0.5f);

        if (hitInfo.collider.tag == "Stairs")
        {
            Debug.Log("eccomi");
            return true;
        }
        else if (hitInfo.collider.tag != "Stairs")
        {
            Debug.Log("bugia");
            return false;
        }
        Debug.Log("default");
        return false;
       
        

    }

}
