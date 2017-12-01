using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEditor;

public class SceneTool : MonoBehaviour {

    
    
    public uint sceneCounter;

    [ReadOnly]
    public string sceneName;

    [HideInEditorMode]
    public string[] buildSceneName;
    
   
	// Use this for initialization
	void Awake () {
        
        buildSceneName = new string[SceneManager.sceneCountInBuildSettings];
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            buildSceneName[i] = EditorBuildSettings.scenes[i].path.ToString();
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (sceneCounter > SceneManager.sceneCountInBuildSettings)
            sceneCounter = (uint)SceneManager.sceneCountInBuildSettings;

        
    }

    private void OnValidate()
    {
        if (sceneCounter > SceneManager.sceneCountInBuildSettings)
            sceneCounter = (uint)SceneManager.sceneCountInBuildSettings;
          
   
    }

    [Button("Carica Scena",ButtonSizes.Medium)]
    public void CaricaScena()
    { 
        SceneManager.LoadSceneAsync((int)sceneCounter);

    }

}
