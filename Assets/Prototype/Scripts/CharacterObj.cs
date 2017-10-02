using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prototype/CharactersObjs")]
public class CharacterObj : ScriptableObject {

    [HideInInspector] public Animator m_Animator;
    [HideInInspector] public Transform m_Camera;                   // A reference to the main camera in the scenes transform
    [HideInInspector] public Transform CharacterTansform;          // A reference to the character assigned to the state controller transform
    [HideInInspector] public Rigidbody m_Rigidbody;                // A reference to the rigidbody
    [HideInInspector] public CapsuleCollider m_Capsule;            // A reference to the capsule collider
}
