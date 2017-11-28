using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using DG.Tweening;
using StateMachine;

namespace Character.Actions
{
    [CreateAssetMenu(menuName = "Prototype/Actions/Characters/InteractAction")]
    public class InteractAction : _Action
    {

        public override void Execute(CharacterStateController controller)
        {
            Interact(controller);
        }

        private void Interact(CharacterStateController controller)
        {
            controller.m_CharacterController.doorObject = controller.m_CharacterController.doorCollider.transform.parent.gameObject;
            RaycastHit hit;

            if (Physics.Raycast(controller.m_CharacterController.playerHead.position,
                controller.m_CharacterController.playerHead.forward, out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromDoor))
            {
                
                // UNLOCKED DOOR
                if (hit.transform.gameObject.tag == "UnlockedDoor")
                {
                    controller.m_CharacterController.isDoorRotate = false;
                    controller.m_CharacterController.isEndDoorAction = true;
                    controller.m_CharacterController.startDoorAction = true;
                    // OPEN THE DOOR
                    if (!hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                    {
                        hit.transform.gameObject.GetComponent<Doors>().OpenDoor();
                        controller.m_CharacterController.isDoorOpen = false;
                  
                    }
                       // CLOSE THE DOOR
                    else if (hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                    {
                        hit.transform.gameObject.GetComponent<Doors>().CloseDoor();
                        controller.m_CharacterController.isDoorOpen = true;
                 
                    }
                }
                // LOCKED DOOR
                else if (hit.transform.gameObject.tag == "LockedDoor")
                {
                    controller.m_CharacterController.isDoorRotate = false;
                    controller.m_CharacterController.isEndDoorAction = true;
                    controller.m_CharacterController.startDoorAction = true;

                    for (int i = 0; i < controller.m_CharacterController.Keychain.Count; i++)
                    {
                        if (hit.transform.gameObject.GetComponent<Doors>().doorID == controller.m_CharacterController.Keychain[i].gameObject.GetComponent<Keys>().ItemID)
                        {
                            controller.m_CharacterController.HideHUDIcons(controller.m_CharacterController.Keychain[i].gameObject.GetComponent<Keys>().icon);

                            hit.transform.gameObject.GetComponent<Doors>().hasKey = true;
                            // OPEN THE DOOR
                            if (!hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                            {
                                hit.transform.gameObject.GetComponent<Doors>().OpenDoor();
                                controller.m_CharacterController.isDoorOpen = false;
                               
                            }
                            // CLOSE THE DOOR
                            else if (hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                            {
                                hit.transform.gameObject.GetComponent<Doors>().CloseDoor();
                                controller.m_CharacterController.isDoorOpen = true;
                               
                            }
                        }
                       
                    }

                }
            }
            
            
        }
    }
}