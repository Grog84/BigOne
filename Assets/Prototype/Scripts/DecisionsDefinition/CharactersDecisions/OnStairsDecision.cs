using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace Character.Decisions
{
    [CreateAssetMenu(menuName = "Prototype/Decisions/Characters/OnStairs")]
    public class OnStairsDecision : Decision
    {

        LayerMask Stairs = 1 << 12;

        public override bool Decide(CharacterStateController controller)
        {
            bool isOnStairs = CheckIsOnStairs(controller);
            return isOnStairs;

        }

        private bool CheckIsOnStairs(CharacterStateController controller)
        {
            RaycastHit hitInfo;
            Ray ray = new Ray(controller.m_CharacterController.CharacterTransform.position, Vector3.down);
            Physics.Raycast(ray, out hitInfo, 0.5f, Stairs);

            if (Physics.Raycast(ray, out hitInfo, 0.5f, Stairs))
            {
                //Debug.Log("eccomi");
                return true;
            }
            else
            {
                //Debug.Log("bugia");
                return false;
            }
            //Debug.Log("default");
            //return false;



        }

    }
}
