using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters;
using System.IO;
using UnityEngine.UI;



public class AT_LoadSceneASync : MonoBehaviour
{

    public Profile Profiler;
    public SaveManager SM;
    AsyncOperation ao;

    public int _index;
    public Text TextBox;

    public RectTransform me;
    public Button LastSceneButton;
    [SerializeField] public Button[] ButtonStatus;

    private void Awake()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "Profile.json");
    }
    string dataPath = "";
    private void Start()
    {
 
        Profiler =Profile.LoadProfile(dataPath);

    }
  
    public void StartLoad(int index)
    {

        for (int i = 0; i < ButtonStatus.Length; i++)
        {
            ButtonStatus[i].interactable = false;
        }
        _index = index;
        StartCoroutine(AsynchronousLoad(_index));
        TextBox.text = "Caricamento in corso";
        StartCoroutine(LoadingText());
    }

    public void LoadLastScene()
    {
        StartCoroutine(AsynchronousLoad(Profiler.LastScene));
        TextBox.text = "Caricamento in corso";
        StartCoroutine(LoadingText());

    }
    public void PressMe()
    {

        me.position = new Vector3(Random.Range(0f, 410.0f), Random.Range(0f, 150.0f));

    }

    public void OnApplicationQuit()
    {
        if (ao != null)
            if (!ao.isDone)
            {
                SceneManager.UnloadSceneAsync(_index);
            }
    }

    IEnumerator AsynchronousLoad(int index)
    {
        yield return null;

        ao = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            Debug.Log("State: " + ao.isDone + " Allowed: " + ao.allowSceneActivation);
          
            if (ao.progress == 0.9f)
            {
                ao.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator LoadingText()
    {      
        yield return null;
    }

    #region Codice Da Trasferire

    //public static void SetLastScene(out int index, out string sceneName)
    //{
    //    List<string> ignoreSceneName = new List<string> { "LG_MenuStart", "LG_Pause_Canvas" };
    //    bool checkIfNotMenuScene = true;
    //    for (int i = 0; i < ignoreSceneName.Count; i++)
    //    {
    //        if (SceneManager.GetActiveScene().name == ignoreSceneName[i])
    //        {
    //            checkIfNotMenuScene = false;
    //        }
    //    }    
    //    if (checkIfNotMenuScene)
    //    {
    //        index = SceneManager.GetActiveScene().buildIndex;
    //        sceneName = SceneManager.GetActiveScene().name;
    //    }
    //    else
    //    {
    //        index = 0;
    //        sceneName = "";
    //    }
    //}

    #endregion
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
