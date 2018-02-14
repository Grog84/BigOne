using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class FMODEventRef
{
    [SerializeField]
    public string audioTag;
    [FMODUnity.EventRef][SerializeField]
    public string audioEntry;
}
