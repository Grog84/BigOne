using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using DG.Tweening;

public class LookAtItems : MonoBehaviour {

    public LookAtIK gazeAt;                       // Take the LookAtIk component we want to move
    public Transform cameraObject;                // Reference to the Camera LookAt object
    public List<Transform> targets;
    public GameObject currentItem;

    [HideInInspector] public float headClamp;    // Reference to the maximum weight according to inspector values

	void Start ()
    {
        targets = new List<Transform>();
        headClamp = gazeAt.solver.headWeight;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            targets.Add(other.transform);
            gazeAt.solver.headWeight = 0;
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
        gazeAt.solver.headWeight = 0;
        currentItem = null;
        if (targets.Count == 0)
        {
            gazeAt.solver.target = cameraObject;
            gazeAt.solver.headWeight = 0;
        }
    }

    void LateUpdate ()
    {
        // Turn head speed
        if (gazeAt.solver.headWeight < headClamp)
        {
            gazeAt.solver.headWeight += Time.deltaTime;
        }

        // Check if currentItem has been picked up
        if (currentItem != null && currentItem.activeSelf == false)
        {   
            targets.Remove(currentItem.transform);
            if (targets.Count == 0)
            {
                gazeAt.solver.target = cameraObject;
                gazeAt.solver.headWeight = 0;
                currentItem = null;
            }
        }
    }
}
