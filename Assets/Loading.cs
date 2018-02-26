using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public Animator anim; 

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadManager.instance.ChangeLevel(anim));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
