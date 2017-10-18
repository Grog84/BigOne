using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkMovement : MonoBehaviour {

    private CharacterController chController;
    private Vector3 m_Move;
    private Transform myTransform;
    private float Speed = 3.0f;



	void Start () {
        chController = this.GetComponent<CharacterController>();
        myTransform = this.transform;
		
	}
	
	
	void Update () {

        m_Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        m_Move = transform.TransformDirection(m_Move);
        m_Move *= Speed;

        chController.Move(m_Move * Time.deltaTime);
    }
}
