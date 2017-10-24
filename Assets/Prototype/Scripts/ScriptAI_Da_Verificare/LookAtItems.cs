using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class LookAtItems : MonoBehaviour {

    public LookAtIK gazeAt;
    public Transform cameraObject;

	void Start ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Interactable layer: " + LayerMask.NameToLayer("Collectable"));
        Debug.Log("Other collider layer: " + other.gameObject.layer);
        if (other.gameObject.layer == LayerMask.NameToLayer("Collectable"))
        {
            Debug.Log("entro");
            gazeAt.solver.IKPosition = other.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        gazeAt.solver.IKPosition = other.transform.position;
    }

    private void OnTriggerExit(Collider other)
    {
        gazeAt.solver.IKPosition = cameraObject.position;
        Debug.Log("esco");
    }

    void LateUpdate ()
    {
        

    }
}
