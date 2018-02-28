using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public Animator anim;
    public Text skipMessage;

	void Start ()
    {
        StartCoroutine(LoadManager.instance.ChangeLevel(anim, skipMessage));
	}
}
