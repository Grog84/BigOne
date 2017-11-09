using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FDMenuUIManager : MonoBehaviour 
{
	public Animator startButtonAnim;
	public Animator settingsButtonAnim;
	public Animator continueAnim;
	public Animator exitGameAnim;
	public Animator audioGameAnim;
	public Animator videoGameAnim;
	public Animator commandsGameAnim;
	public Animator backGameAnim;

	public void StartGame () 
	{
		SceneManager.LoadScene ("FG_MappaP_01");
		Debug.Log ("CHIAMO SCENA DI FACUNDO");
	}

	public void OpenSettings()
	{
		settingsButtonAnim.SetBool ("IsHidden", true);
	}

	public void CloseSettings()
	{
		settingsButtonAnim.SetBool ("IsHidden", false);
	}

	public void slideMenu()
	{
		bool isHidden = exitGameAnim.GetBool ("IsHidden");
		exitGameAnim.SetBool ("isHidden", !isHidden);
	}

	public void Continue()
	{
		
	}

}