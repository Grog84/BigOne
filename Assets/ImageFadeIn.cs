using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageFadeIn : MonoBehaviour
{
    public Image[] image;
    public float startFadeInTimer;
    public float fadeInSpeed;

    void Start ()
    { 
        StartCoroutine(StartFadeIn());
	}
	
    IEnumerator StartFadeIn()
    {
        for (int i = 0; i < image.Length; i++)
        {
            Debug.Log("start fade in");
            StartCoroutine(FadeIn(image[i]));
            yield return new WaitForSeconds(startFadeInTimer);
        }

        yield return null;
    }


    IEnumerator FadeIn(Image image)
    {
        Debug.Log("fade in");
        image.GetComponent<Animator>().speed = fadeInSpeed;
        image.GetComponent<Animator>().enabled = true;
        yield return null;
    }

}
