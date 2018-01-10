#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tools/DeveloperProfile")]
[System.Serializable]
public class DeveloperProfile : ScriptableObject
{
    [SerializeField]
    public MapToolConfig mapConfig ;

    
}
#endif
