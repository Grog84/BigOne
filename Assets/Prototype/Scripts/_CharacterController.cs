using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CharacterController : MonoBehaviour {

    [HideInInspector] public float m_MoveSpeedMultiplier;
    [HideInInspector] public float m_TurnAmount;
    [HideInInspector] public float m_ForwardAmount;

    private StateController controller;

    // Use this for initialization
    void Start () {

        controller.GetComponent<StateController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnAnimatorMove()
    {
        bool m_IsGrounded = controller.characterObj.m_Animator.GetBool("OnGround");

        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        if (m_IsGrounded && Time.deltaTime > 0)
        {
            Vector3 v = (controller.characterObj.m_Animator.deltaPosition * m_MoveSpeedMultiplier) / Time.deltaTime;

            // we preserve the existing y part of the current velocity.
            v.y = controller.characterObj.m_Rigidbody.velocity.y;
            controller.characterObj.m_Rigidbody.velocity = v;
        }
    }
}
