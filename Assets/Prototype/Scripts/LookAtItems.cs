using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using DG.Tweening;
using Character;

public class LookAtItems : MonoBehaviour {

    [HideInInspector] public _CharacterController controller;
    [HideInInspector] public LookAtIK gazeAt;                       // Take the LookAtIk component we want to move
    [HideInInspector] public Transform cameraObject;                // Reference to the Camera LookAt object
    public List<Transform> targets;
    public GameObject currentItem;

	void Start ()
    {
        controller = transform.parent.GetComponent<_CharacterController>();
        gazeAt = controller.playerSight;
        targets = new List<Transform>();
        cameraObject = controller.cameraObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            targets.Add(other.transform);
            controller.dontLookAt = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        for (int i = 0; i < targets.Count; i++)
        {
            if(i == 0)
            {
                gazeAt.solver.target = targets[i];
                currentItem = targets[i].gameObject;
            }
            // Look the closest item
            else if ((Vector3.Distance(gameObject.transform.parent.position, targets[i].position)) < 
                   (Vector3.Distance(gameObject.transform.parent.position, targets[i-1].position)))
                 {
                     gazeAt.solver.target = targets[i];
                     currentItem = targets[i].gameObject;
                 }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.transform);
        controller.dontLookAt = true;
        currentItem = null;

        if (targets.Count == 0)
        {
            StandardTarget();
        }
    }

    void StandardTarget()
    {
        if(controller.isDontLookAtDone)
        {
            gazeAt.solver.target = cameraObject;
        }
    }

    void LateUpdate ()
    {
        if(controller.isDontLookAtDone && gazeAt.solver.headWeight <= 0)
        {
            controller.canLookAt = true;
        }

        // Check if currentItem has been picked up
        if (currentItem != null && currentItem.activeSelf == false)
        {   
            targets.Remove(currentItem.transform);
            if (targets.Count == 0)
            {
                controller.dontLookAt = true;
                StandardTarget();
                currentItem = null;
            }
        }
    }
}
