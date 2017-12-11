using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

[CreateAssetMenu(menuName = "Tools/MapToolConfig")]
[System.Serializable]
public class MapToolConfig : ScriptableObject
{
#if UNITY_EDITOR
    [SerializeField]
    public SceneSetup[] sceneSetup;
#endif
}
