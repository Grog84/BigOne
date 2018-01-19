using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public Transform canvasPause;
    public bool canvasTrigger = false;

	// Update is called once per frame
 


    public void Awake()
    {
        canvasPause.gameObject.SetActive(false);
    }

    private void Start()
    {
  
        
    }

    public void ReturnMenu()
    {
   
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
