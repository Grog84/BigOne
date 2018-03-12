using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class waterFloating : MonoBehaviour {

	public float waterLevel = -1f;
	public float floatHeight = 2f; 
	public float bounceDamp = 0.05f;
	public Vector3 buoyancyCentreOffset;

	private float forceFactor;
	private Vector3 actionPoint;
	private Vector3 upLift;

	Rigidbody rb;

	
	void Awake ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () 
	{
		if (floatHeight == 0) //se è zero esplode tutto
			floatHeight = 0.1f;
		
		actionPoint = transform.position + transform.TransformDirection (buoyancyCentreOffset);
		//Debug.Log("x " + actionPoint.x + " y " + actionPoint.y + " z " + actionPoint.z); 
		forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		//Debug.Log (actionPoint.y);



		if(forceFactor > 0f)
		{
			upLift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
			rb.AddForceAtPosition (upLift, actionPoint);
		}
	}
}
