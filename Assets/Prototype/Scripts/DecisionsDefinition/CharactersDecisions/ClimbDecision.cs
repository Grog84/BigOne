using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/Decisions/Characters/ClimbDecision")]
public class ClimbDecision : Decision
{
    public override bool Decide(CharacterStateController controller)
    {
        bool isClimbing = CheckIfClimbing(controller);
        return isClimbing;
    }

    private bool CheckIfClimbing(CharacterStateController controller)
    {
        if (controller.GetComponent<_CharacterController>().isClimbable == true)
        {


            RaycastHit hit = new RaycastHit();
            float distance = controller.characterStats.m_RaycastClimb;

            if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit, distance))
            {
                Debug.DrawLine(controller.transform.position, hit.point);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Climbable"))
                {
                    return true;
                }
            }


        }

        return false;
    }


}
