using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingLevelImage : MonoBehaviour
{
    public GameObject[] imageList;

	void Start ()
    {
        for (int i = 0; i < imageList.Length; i++)
        {
            if(LoadManager.instance.loadSelected)
            {
                if (SceneManager.GetSceneByBuildIndex(LoadManager.instance.currentSceneIndex).name == imageList[i].name)
                {
                    imageList[i].SetActive(true);
                    LoadManager.instance.loadSelected = false;
                }
            }
            else if(SceneManager.GetSceneByBuildIndex(LoadManager.instance.currentSceneIndex + 1).name == imageList[i].name)
            {
                imageList[i].SetActive(true);
            }
        }
	}
	
}
