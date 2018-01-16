using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvasPause;
    public bool canvasTrigger = false;

    private CheckPointManager CP_Controller;
   [SerializeField] private  QuestManager.QuestManager QM_Controller;
    

	// Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            Pause();       
        }
    }


    public void Awake()
    {
        canvasPause.gameObject.SetActive(false);
    }

    private void Start()
    {
        //QM_Controller.ShowActiveQuestOnMenu();
       // canvasPause.gameObject.SetActive(false);
        
    }


	public void Pause()
	{
		canvasTrigger = !canvasTrigger;
		if (canvasTrigger)
		{
			canvasPause.gameObject.SetActive(true);
		}
		else
		{
			canvasPause.gameObject.SetActive(false);
		}
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
        SaveManager Gc = FindObjectOfType<SaveManager>();
        Gc.Load();
    }

}
