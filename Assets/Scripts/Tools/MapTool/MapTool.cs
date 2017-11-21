using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MapTool : MonoBehaviour
{

    public MapToolConfig myConfigFile;

    public void SaveConfig()
    {
        myConfigFile.sceneSetup = EditorSceneManager.GetSceneManagerSetup();
    }

    public void LoadConfig()
    {
        EditorSceneManager.RestoreSceneManagerSetup(myConfigFile.sceneSetup);
    }

}
