using System.Collections;
using UnityEngine;
using UnityEngine.UI;



public class AT_ButtonFade:MonoBehaviour
    {
    [SerializeField] public Button[] SceneStatus;
    private Image[] ImageStatus;
    private void Start()
    {
        ImageStatus = new Image[SceneStatus.Length];
        for (int i = 0; i < SceneStatus.Length; i++)
        {
            ImageStatus[i] = SceneStatus[i].gameObject.GetComponent<Image>();
        }
    }


    public void FadeOut()
    {

        StartCoroutine(fadeOut());

    }
    public void FadeIn()
    {
        StartCoroutine(fadeIn());

    }
    IEnumerator fadeOut()
    {
        foreach (Image yourNameHere in ImageStatus)
        {
            while (yourNameHere.color.a > 0)
            {                   //use "< 1" when fading in
                yourNameHere.color = new Color(yourNameHere.color.r, yourNameHere.color.g, yourNameHere.color.b, yourNameHere.color.a - Time.deltaTime / 1);    //fades out over 1 second. change to += to fade in  
                yourNameHere.transform.GetChild(0).GetComponent<Text>().color = new Color(yourNameHere.transform.GetChild(0).GetComponent<Text>().color.r,
                    yourNameHere.transform.GetChild(0).GetComponent<Text>().color.g, yourNameHere.transform.GetChild(0).GetComponent<Text>().color.b,
                    yourNameHere.transform.GetChild(0).GetComponent<Text>().color.a - Time.deltaTime / 1);
                yield return null;
            }
            if (yourNameHere.color.a < 0)
            {
                yourNameHere.gameObject.SetActive(false);
                yield return null;
            }
        }
    }

    IEnumerator fadeIn()
    {
        foreach (Image yourNameHere in ImageStatus)
        {

            yourNameHere.gameObject.SetActive(true);


            while (yourNameHere.color.a < 1)
            {                   //use "< 1" when fading in
                yourNameHere.color = new Color(yourNameHere.color.r, yourNameHere.color.g, yourNameHere.color.b, yourNameHere.color.a + Time.deltaTime / 1);    //fades out over 1 second. change to += to fade in  
                yourNameHere.transform.GetChild(0).GetComponent<Text>().color = new Color(yourNameHere.transform.GetChild(0).GetComponent<Text>().color.r,
                    yourNameHere.transform.GetChild(0).GetComponent<Text>().color.g, yourNameHere.transform.GetChild(0).GetComponent<Text>().color.b,
                    yourNameHere.transform.GetChild(0).GetComponent<Text>().color.a + Time.deltaTime / 1);
                yield return null;
            }
        }
    }
}
