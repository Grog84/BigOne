using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	public float moveSpeed;
	//public Rigidbody theRB;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;
	public float gravityScale;

	public Animator anim;

	public float turnRate;
	private float horizontalAxis;
	private float verticalAxis;



	// Use this for initialization
	void Start () {

		controller = GetComponent<CharacterController>();

	
	}
	
	// Update is called once per frame
	void Update () {
		


	
		// check if is grounded to Jump
		moveDirection = new Vector3 (Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

		if (controller.isGrounded)
		{
		
			if (Input.GetButtonDown ("Jump")) 
			{
		
				moveDirection.y = jumpForce;
			}


		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move (moveDirection * Time.deltaTime);

	
		anim.SetBool ("isGrounded", controller.isGrounded);
		anim.SetFloat ("speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal")) ));

		//Move PLayer in diferent directions
		if(Input.GetAxis("Horizontal") != 0  && Input.GetAxis("Vertical") !=0 || Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") !=0 )

		{
			horizontalAxis = Input.GetAxis("Horizontal");
			verticalAxis = Input.GetAxis ("Vertical")* -1;
			transform.forward = Vector3.Lerp(transform.forward, new Vector3(verticalAxis, 0f, horizontalAxis), Time.deltaTime * turnRate);

		}
	}
}
