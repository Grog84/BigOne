using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersStats")]
public class CharacterStats : ScriptableObject { // nope...here stats only should be present, another SO should contain the gameobj refs

   
    [Header("Character Movement Parameters")]
    public float m_WalkSpeed = 3.0f;
    public float m_WalkOnStairsSpeed = 3.0f;
    public float m_CrouchSpeed = 3.0f;
    public float m_CrouchOnStarisSpeed = 3.0f;
    public float m_RunSpeed = 3.0f;
    public float m_RunOnStarisSpeed = 3.0f;
    public float m_RotateSpeed = 3.0f;
    public float m_MovementSpeed = 3.0f;
    [Space(10)]
    public float m_ClimbSpeed = 3.0f;
    public float m_DistanceFromWallClimbing = 4f;
    public float m_ClimbFallHeight = 1f;
    [Space(10)]
    public float m_PushSpeed = 3.0f;
    public float m_DistanceFromPushableObject = 4f;
    public float m_DistanceFromPushableObstacle = 5f;
    [Space(10)]
    public float m_BalanceMovementSpeed = 0.5f;
    [Space(10)]
    public float m_DistanceFromDoor = 4f;
    [Space(10)]
    [Header("Character Gravity Parameters")]
    public float m_GroundCheckDistance = 0.1f;
    public float m_Gravity = 3.0f;
    public float m_DefaultGravity = 0f;
    [HideInInspector]public float m_JumpHeight = 3.0f;
    public float m_FallGravity = 3.0f;
    public float m_StairsGravity = 3.0f;
    [Space(10)]
    [Header("Character Noise Parameters")]
    public float m_WalkSoundrange = 3.0f;
    public float m_CrouchSoundrange = 1.0f;
    public float m_RunSoundrange = 5.0f;
    [Space(10)]
    [Range(1, 99)]
    public float m_InnerAreaPerc = 30;

    [Space(10)]
    [Header("Character Collider Parameters")]
    public float crouchedColliderHeightDimension = 0.0f;
    public float crouchedColliderYOffset = 0.0f;
    public float standingColliderHeightDimension = 0.0f;
    public float standingColliderYOffset = 0.0f;

}
