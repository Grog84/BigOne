using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingLevelImage : MonoBehaviour
{
    public GameObject[] imageList;
    public int startIndexOffset;

	void Start ()
    {
        imageList[LoadManager.instance.currentSceneIndex + 1 - startIndexOffset].SetActive(true);
	}
	
}
