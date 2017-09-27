using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : ScriptableObject { // nope...here stats only should be present, another SO should contain the gameobj refs

    public Transform m_Cam;                   // A reference to the main camera in the scenes transform
    public Transform CharacterTansform;       // A reference to the character assigned to the state controller transform

}
