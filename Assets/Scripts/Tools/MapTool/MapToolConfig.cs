#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;


[CreateAssetMenu(menuName = "Tools/MapToolConfig")]
[System.Serializable]
public class MapToolConfig : ScriptableObject
{

    [SerializeField]
    public SceneSetup[] sceneSetup;
}
#endif
