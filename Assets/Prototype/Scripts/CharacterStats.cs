using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersStats")]
public class CharacterStats : ScriptableObject { // nope...here stats only should be present, another SO should contain the gameobj refs

    //Ethan
    public float m_MovingTurnSpeed = 360;
    public float m_StationaryTurnSpeed = 180;
    public float m_JumpPower = 12f;
    [Range(1f, 4f)] public float m_GravityMultiplier = 2f;
    public float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
    public float m_NormalSpeedMultiplier = 1f;
    public float m_CrouchSpeedMultiplier = 0.8f;
    public float m_RunSpeedMultiplier = 1.2f;
    public float m_AnimSpeedMultiplier = 1f;
    public float m_GroundCheckDistance = 0.1f;

    //New Implementation
    public float m_RotateSpeed = 3.0f;
    public float m_WalkSpeed = 3.0f;
    public float m_CrouchSpeed = 3.0f;
    public float m_RunSpeed = 3.0f;
    public float m_Gravity = 3.0f;
    public float m_JumpHeight = 3.0f;
    public float m_ClimbSpeed = 3.0f;
    public float m_RaycastClimb = 3.0f;
}
