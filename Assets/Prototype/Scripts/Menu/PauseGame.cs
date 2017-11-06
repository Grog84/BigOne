using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;
    public bool canvasTrigger = false;

    private CheckPointManager CP_Controller;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasTrigger = !canvasTrigger;
            Pause();
        }

    }
    public void Pause()
    {
        if (canvasTrigger)
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }


    }
    public void ResumeGame()
    {

        canvasTrigger = !canvasTrigger;
        Pause();
    }
    public void ReturnMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void ReloadScene()
    {
        int SceneIndex;
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneIndex);
    }

    public void LastCheckPoint()
    {
        CP_Controller = GetComponent<CheckPointManager>();
        Time.timeScale = 1;
        CP_Controller.LoadAllObj();
    }

}
