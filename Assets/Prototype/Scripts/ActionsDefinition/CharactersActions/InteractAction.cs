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
            
            RaycastHit hit;
            Debug.DrawRay(controller.m_CharacterController.CharacterTransform.position + Vector3.up * controller.m_CharacterController.m_CharController.bounds.size.y / 2.0f, controller.m_CharacterController.CharacterTransform.forward, Color.red);

            if (Physics.Raycast(controller.m_CharacterController.CharacterTransform.position + Vector3.up * controller.m_CharacterController.m_CharController.bounds.size.y / 2.0f,
                controller.m_CharacterController.CharacterTransform.forward, out hit, controller.m_CharacterController.m_CharStats.m_DistanceFromWallClimbing))
            {
                Debug.Log("vedo");

                if (hit.transform.gameObject.tag == "UnlockedDoor")
                {
                    if (!hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                    {
                        Debug.Log("APRI LA PORTA");
                        hit.transform.gameObject.GetComponent<Doors>().isDoorOpen = true;
                        controller.m_CharacterController.doorCollider.transform.parent.transform.Find("Hinge").DORotate(new Vector3(0, -90, 0), 2f);
                    }
                    else if (hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                    {
                        Debug.Log("CHIUDI LA PORTA");
                        hit.transform.gameObject.GetComponent<Doors>().isDoorOpen = false;
                        controller.m_CharacterController.doorCollider.transform.parent.transform.Find("Hinge").DORotate(new Vector3(0, 0, 0), 2f);
                    }
                }
                else
                {
                    for (int i = 0; i < controller.m_CharacterController.Keychain.Count; i++)
                    {
                        if (hit.transform.gameObject.GetComponent<Doors>().doorID == controller.m_CharacterController.Keychain[i].gameObject.GetComponent<Keys>().keyID)
                        {
                            if (!hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                            {
                                Debug.Log("APRI LA PORTA");
                                hit.transform.gameObject.GetComponent<Doors>().isDoorOpen = true;
                                controller.m_CharacterController.doorCollider.transform.parent.transform.Find("Hinge").DORotate(new Vector3(0, -90, 0), 2f);
                            }
                            else if (hit.transform.gameObject.GetComponent<Doors>().isDoorOpen)
                            {
                                Debug.Log("CHIUDI LA PORTA");
                                hit.transform.gameObject.GetComponent<Doors>().isDoorOpen = false;
                                controller.m_CharacterController.doorCollider.transform.parent.transform.Find("Hinge").DORotate(new Vector3(0, 0, 0), 2f);
                            }
                        }
                    }

                }
            }
            // }
            //}
        }
    }
}