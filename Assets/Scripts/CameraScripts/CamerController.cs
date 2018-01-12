using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerController : MonoBehaviour {

	public Transform target;
	public Vector3 rotationOffset = new Vector3(0f,1f,0f);
	private Vector3 finalTarget;



	public Vector3 positionOffset= new Vector3(0f,  -2.5f, 7f);
	private Vector3 targetPosition;
	public float cameraRotationSpeed= 0.3f;
	//private float ActualcameraRotationSpeed;
	private float targetSpeed;



	// Use this for initializationzzzzzzzzzzzzzzzzz
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {




		//ActualcameraRotationSpeed = cameraRotationSpeed * targetSpeed;

		transform.position =  Vector3.Lerp(transform.position, target.position - positionOffset , cameraRotationSpeed);

		transform.LookAt (target);
	}
}
