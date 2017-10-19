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
    [Header("Character Movement Parameters")]
    public float m_WalkSpeed = 3.0f;
    public float m_CrouchSpeed = 3.0f;
    public float m_RunSpeed = 3.0f;
    public float m_RotateSpeed = 3.0f;
    public float m_MovementSpeed = 3.0f;
    [Space(10)]
    public float m_ClimbSpeed = 3.0f;
    public float m_DistanceFromWallClimbing = 4f; 
    [Space(10)]
    public float m_PushSpeed = 3.0f;
    public float m_DistanceFromPushableObject = 4f;
    public float m_DistanceFromPushableObstacle = 5f;
    [Range(-1,1)]
    public float m_PushableObjectRaycastOffset = 0;
    [Space(10)]
    public float m_DistanceFromDoor = 4f;
    [Space(10)]
    public float m_Gravity = 3.0f;
    public float m_JumpHeight = 3.0f;
    public float m_FallGravity = 3.0f;
    public float m_StairsGravity = 3.0f;
    [HideInInspector]public float m_DefaultGravity = 0f;
    [Space(10)]
    [Header("Character Noise Parameters")]
    public float m_WalkSoundrange = 3.0f;
    public float m_CrouchSoundrange = 1.0f;
    public float m_RunSoundrange = 5.0f;
   
    
}
