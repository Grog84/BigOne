using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateController : StateController {

    public CharacterStats characterStats;
    public CharacterObj characterObj;
    [HideInInspector] public _CharacterController m_CharacterController;

    // Use this for initialization
    protected override void Awake ()
    {
        base.Awake();
        characterObj.CharacterTansform = GetComponent<Transform>();          // A reference to the character assigned to the state controller transform
        //characterObj.m_Rigidbody = GetComponent<Rigidbody>();                // A reference to the rigidbody
        //characterObj.m_Capsule = GetComponent<CapsuleCollider>();            // A reference to the capsule collider
        characterObj.m_Animator = GetComponent<Animator>();
        characterObj.m_CharController = GetComponent<CharacterController>();

        GameObject m_CameraObj = GameObject.FindGameObjectsWithTag("MainCamera")[0];
        characterObj.m_Camera = m_CameraObj.transform;
    }

    public override void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState.OnExitState(this);
            currentState = nextState;
            currentState.OnEnterState(this);
            OnExitState();
        }
    }

    protected override void Update()
    {
        base.Update();
        currentState.UpdateState(this);
    }

}
