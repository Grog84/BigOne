using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFadeIn : MonoBehaviour
{
    public Text[] text;
    public float startFadeInTimer;
    public float fadeInSpeed;

    void Start ()
    { 
        StartCoroutine(StartFadeIn());
	}
	
    IEnumerator StartFadeIn()
    {
        for (int i = 0; i < text.Length; i++)
        {
            //Debug.Log("start fade in");
            StartCoroutine(FadeIn(text[i]));
            yield return new WaitForSeconds(startFadeInTimer);
            text[i].enabled = false;
        }

        yield return null;
    }


    IEnumerator FadeIn(Text text)
    {
       // Debug.Log("fade in");
        text.GetComponent<Animator>().speed = fadeInSpeed;
        text.GetComponent<Animator>().enabled = true;
        yield return null;
    }

}
