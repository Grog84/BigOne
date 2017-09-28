using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObj : ScriptableObject {

    public Transform m_Camera;                   // A reference to the main camera in the scenes transform
    public Transform CharacterTansform;          // A reference to the character assigned to the state controller transform
    public Rigidbody m_Rigidbody;                // A reference to the rigidbody
    public CapsuleCollider m_Capsule;            // A reference to the capsule collider
}
