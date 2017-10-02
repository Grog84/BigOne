using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject { // nope...here stats only should be present, another SO should contain the gameobj refs

    public float m_MovingTurnSpeed = 360;
    public float m_StationaryTurnSpeed = 180;
    public float m_JumpPower = 12f;
    [Range(1f, 4f)] public float m_GravityMultiplier = 2f;
    public float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
    public float m_MoveSpeedMultiplier = 1f;
    public float m_AnimSpeedMultiplier = 1f;
    public float m_GroundCheckDistance = 0.1f;

}
