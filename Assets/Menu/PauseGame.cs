using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvas;
    public bool canvasTrigger = false;

    private CheckPointManager CP_Controller;
   [SerializeField] private  MissionManagerStuff.QuestManager QM_Controller;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Pause();
            QM_Controller.ShowActiveQuestOnMenu();
        }

    }
    public void Pause()
    {
        canvasTrigger = !canvasTrigger;
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
    public void Awake()
    {
        canvas.gameObject.SetActive(true);

        QM_Controller.ShowActiveQuestOnMenu();
        canvas.gameObject.SetActive(false);
        
    }
    public void ResumeGame()
    {
       
        Pause();
    }
    public void ReturnMenu()
    {
        ////Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void ReloadScene()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LastCheckPoint()
    {
        GameController Gc = FindObjectOfType<GameController>();
        Gc.Load();
    }

}
