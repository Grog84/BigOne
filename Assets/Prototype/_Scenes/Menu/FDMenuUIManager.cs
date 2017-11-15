using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FDMenuUIManager : MonoBehaviour
{
    public Animator startButtonAnim;
    public Animator optionButtonAnim;
    public Animator continueAnim;
    public Animator exitGameAnim;
    public Animator audioGameAnim;
    public Animator videoGameAnim;
    public Animator commandsGameAnim;
    public Animator backMenuAnim;
    public Animator audioMenu;
    public Animator videoMenu;
    public Animator schemeControlls;

    public void StartGame()
    {
        Debug.Log("CHIAMO SCENA DI FACUNDO");
        SceneManager.LoadScene("FG_MappaP_01");
    }

    public void OpenSettings()
    {
        startButtonAnim.SetBool("IsHidden", true);
        optionButtonAnim.SetBool("IsHidden", true);
        continueAnim.SetBool("IsHidden", true);
        exitGameAnim.SetBool("IsHidden", true);
        audioGameAnim.SetBool("IsHidden", false);
        videoGameAnim.SetBool("IsHidden", false);
        commandsGameAnim.SetBool("IsHidden", false);
        backMenuAnim.SetBool("IsHidden", false);
    }

    public void CloseSettings()
    {
        startButtonAnim.SetBool("IsHidden", false);
        optionButtonAnim.SetBool("IsHidden", false);
        continueAnim.SetBool("IsHidden", false);
        exitGameAnim.SetBool("IsHidden", false);
        audioGameAnim.SetBool("IsHidden", true);
        videoGameAnim.SetBool("IsHidden", true);
        commandsGameAnim.SetBool("IsHidden", true);
        backMenuAnim.SetBool("IsHidden", true);
        audioMenu.SetBool("Audio", false);
        videoMenu.SetBool("Video", false);
        schemeControlls.SetBool("Input", false);
    }

    public void AudioMenuEnter()
    {
        if(videoMenu == true)
            {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            videoMenu.SetBool("Video", false);
        }
        if (schemeControlls == true)
        {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            schemeControlls.SetBool("Input", false);
        }
        Debug.Log("CHIAMO SCENA DI FACUNDO");
        audioMenu.SetBool("Audio", true);
    }

    public void VideoMenuEnter()
    {
        if (audioMenu == true)
        {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            audioMenu.SetBool("Audio", false);
        }
        if (schemeControlls == true)
        {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            schemeControlls.SetBool("Input", false);
        }
        Debug.Log("CHIAMO SCENA DI FACUNDO");
        videoMenu.SetBool("Video", true);
    }

    public void Controlls()
    {
        if (audioMenu == true)
        {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            audioMenu.SetBool("Audio", false);
        }
        if (videoMenu == true)
        {
            Debug.Log("CHIAMO SCENA DI FACUNDO");
            videoMenu.SetBool("Video", false);
        }
        Debug.Log("CHIAMO SCENA DI FACUNDO");
        schemeControlls.SetBool("Input", true);
    }



	public void Continue()
	{
		
	}



    public void Exit()
    {
        Application.Quit();
    }

}