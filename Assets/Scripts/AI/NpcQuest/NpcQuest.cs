using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class NpcQuest : MonoBehaviour {

    [HideInInspector]public bool playerSaw = false;
    Transform eyes;
    LookAtIK lookAtComponent;
    [HideInInspector] public bool canInteract = true;
    public Transform lookAtTarget;
    [HideInInspector]public Animator m_Animator;

    [HideInInspector] public float headClamp;    // Reference to the maximum weight according to inspector values

    public void LookAtManager()
    {
        if (playerSaw)
        {

            lookAtComponent.solver.target = lookAtTarget;
            // Turn head speed
            if (lookAtComponent.solver.headWeight < headClamp)
            {
                lookAtComponent.solver.headWeight += Time.deltaTime;
            }
        }
        
    }

    public void SetInteractionFalse()
    {
        canInteract = true;
    }

    public void StopWaving()
    {
        m_Animator.SetBool("PlayerSaw", false);
    }

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        lookAtComponent = GetComponent<LookAtIK>();
    }

    private void Update()
    {
        LookAtManager();

    }


}
