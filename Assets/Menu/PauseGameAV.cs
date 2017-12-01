using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGameAV : MonoBehaviour
{
    private int index = 0;
    public GameObject canvas;
    public bool canvasTrigger = false;

    private CheckPointManager CP_Controller;

    // Update is called once per frame
    void Update()
    {
        if(!canvasTrigger)
        {
            if (Input.GetButtonDown("Pause"))
            {
                Debug.Log("dsa");
                canvasTrigger = true;
                Pause();
            }
        }
        else
        {
            if (Input.GetButtonDown("Pause"))
            {
                canvasTrigger = false;
                Pause();
            }
        }
        
        if(canvasTrigger)
        {
            bool toggled = false;
            if(Input.GetAxis("Vertical") < 0 && !toggled && index < 3)
            {
                toggled = true;
                index++;
            }
            else if (Input.GetAxis("Vertical") > 0 && !toggled && index > 0)
            {
                toggled = true;
                index--;
            }
        }

        if(index == 0 && Input.GetButtonDown("Interact"))
        {
            ResumeGame();
        }
        else if(index == 1 && Input.GetButtonDown("Interact"))
        {

        }



    }
    public void Pause()
    {
        if (canvasTrigger)
        {
            GMController.instance.isGameActive =false;
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            GMController.instance.isGameActive = true;
            canvas.SetActive(false);
            Time.timeScale = 1;
        }


    }
    public void ResumeGame()
    {
        canvasTrigger = false;
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
