using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AT_LoadSceneASync : MonoBehaviour {
   
    AsyncOperation ao;

    public int _index;

    public Text TextBox;

    public RectTransform me;

    [SerializeField] public Button[] SceneStatus;
  
    private void Start()
    {
        InizializeLevelButton();
     
    }
    //   public Image yourNameHere;
    public void StartLoad(int index)
    {
        _index = index;
        StartCoroutine(AsynchronousLoad(index));
        TextBox.text = "Caricamento in corso";
        StartCoroutine(LoadingText());
    }
     
    public void PressMe()
    {
   
        me.position = new Vector3(Random.Range(0f, 410.0f), Random.Range(0f, 150.0f));

    }

    public void OnApplicationQuit()
    {
       // SceneManager.UnloadSceneAsync(_index);
    }
     
    public void InizializeLevelButton()
    {   Dropdown ProfileDropDown = GameObject.FindObjectOfType<Dropdown>();
        bool[] temp;
        //Check the Dropdown current Profile Loaded
        temp=SetCondition(ProfileDropDown.value);
        //on every Profile there are several check on current / completed Levels
        for (int i = 0; i < temp.Length; i++)
        {
           if(temp[i])
            {
                SceneStatus[i].gameObject.SetActive(true);
            }
           else
            {
                SceneStatus[i].gameObject.SetActive(false);
            }
        }

        //And inizialize all button based on those info;

    }
   
    private bool[] SetCondition(int value)
    {//Don't care about this...
          
        switch (value)
        {
            case 0:
                return new bool[] { true, true, false, false };
               
            case 1:
                return  new bool[] { true, false, false, false };
           
            case 2:
                return  new bool[] { true, true, true, true };
            default:
                return new bool[] { false, false, false, false };
               

        }
  
    }

   IEnumerator AsynchronousLoad(string scene)
    {
     //   yield return null;

      ao= SceneManager.LoadSceneAsync(scene,LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            Debug.Log("State: " + ao.isDone + " Allowed: " + ao.allowSceneActivation);
            // Loading completed
            if (ao.progress == 0.9f)
            {            
                    ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator AsynchronousLoad(int index)
    {
        //   yield return null;

        ao = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            Debug.Log("State: " + ao.isDone + " Allowed: " + ao.allowSceneActivation);
            // Loading completed
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator LoadingText()
    {
        while (!ao.isDone)
        {

            switch (TextBox.text)
            {
                case "Caricamento in corso":
                    TextBox.text = "Caricamento in corso.";
                    yield return new WaitForSecondsRealtime(00.5f) ;
                    break;
                case "Caricamento in corso.":
                    TextBox.text = "Caricamento in corso..";
                    yield return new WaitForSecondsRealtime(00.5f);
                    break;
                case "Caricamento in corso..":
                    TextBox.text = "Caricamento in corso...";
                    yield return new WaitForSecondsRealtime(00.5f) ;
                    break;
                case "Caricamento in corso...":
                    TextBox.text = "Caricamento in corso";
                    yield return new WaitForSecondsRealtime(00.5f);
                    break;

            }
        }
        yield return null;

    }

    #region FadeButton
    //public void FadeOut()
    //{

    //    StartCoroutine(fadeOut());

    //}
    //public void fadeIn()
    //{
    //    StartCoroutine(FadeIn());

    //}
    //IEnumerator fadeOut()
    //{
    //    foreach (Image yourNameHere in ImageStatus)
    //    {
    //        while (yourNameHere.color.a > 0)
    //        {                   //use "< 1" when fading in
    //            yourNameHere.color = new Color(yourNameHere.color.r, yourNameHere.color.g, yourNameHere.color.b, yourNameHere.color.a - Time.deltaTime / 1);    //fades out over 1 second. change to += to fade in  
    //            yourNameHere.transform.GetChild(0).GetComponent<Text>().color = new Color(yourNameHere.transform.GetChild(0).GetComponent<Text>().color.r,
    //                yourNameHere.transform.GetChild(0).GetComponent<Text>().color.g, yourNameHere.transform.GetChild(0).GetComponent<Text>().color.b,
    //                yourNameHere.transform.GetChild(0).GetComponent<Text>().color.a - Time.deltaTime / 1);
    //            yield return null;
    //        }
    //        if (yourNameHere.color.a < 0)
    //        {
    //            yourNameHere.gameObject.SetActive(false);
    //            yield return null;
    //        }
    //    }
    //}

    //IEnumerator FadeIn()
    //{
    //    foreach (Image yourNameHere in ImageStatus)
    //    {
    //        yourNameHere.gameObject.SetActive(true);


    //    while (yourNameHere.color.a <1)
    //    {                   //use "< 1" when fading in
    //        yourNameHere.color = new Color(yourNameHere.color.r, yourNameHere.color.g, yourNameHere.color.b, yourNameHere.color.a +Time.deltaTime / 1);    //fades out over 1 second. change to += to fade in  
    //        yourNameHere.transform.GetChild(0).GetComponent<Text>().color = new Color(yourNameHere.transform.GetChild(0).GetComponent<Text>().color.r,
    //            yourNameHere.transform.GetChild(0).GetComponent<Text>().color.g, yourNameHere.transform.GetChild(0).GetComponent<Text>().color.b,
    //            yourNameHere.transform.GetChild(0).GetComponent<Text>().color.a + Time.deltaTime / 1);
    //        yield return null;
    //    }
    //    }
    //}
#endregion
}
