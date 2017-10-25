using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;
using DG.Tweening;

public class LookAtItems : MonoBehaviour {

    public LookAtIK gazeAt;
    public Transform cameraObject;

    public List<Transform> targets;
    public float maxHeadWeight;
    public float headClamp;


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
            }
            
            else if ((Vector3.Distance(gameObject.transform.parent.position, targets[i].position)) < 
                   (Vector3.Distance(gameObject.transform.parent.position, targets[i-1].position)))
                 {
                     gazeAt.solver.target = targets[i];
                 }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        targets.Remove(other.transform);
        gazeAt.solver.headWeight = 0;

        if (targets.Count == 0)
        {
            gazeAt.solver.target = cameraObject;
            gazeAt.solver.headWeight = 0;
        }
    }

    void LateUpdate ()
    {
        if (gazeAt.solver.headWeight < headClamp)
        {
            gazeAt.solver.headWeight += Time.deltaTime;
        }

    }
}
