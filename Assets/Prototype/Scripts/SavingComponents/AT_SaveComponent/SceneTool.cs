using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using UnityEngine;

public class SceneTool : MonoBehaviour {

    
    public uint sceneCounter;

    [ReadOnly]
    public string sceneName;
    
   
	// Use this for initialization
	void Start () {


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
