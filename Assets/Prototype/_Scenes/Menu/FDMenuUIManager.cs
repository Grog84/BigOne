using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FDMenuUIManager : MonoBehaviour 
{
	public Animator startButtonAnim;
	public Animator settingsButtonAnim;
	public Animator settingsPanelAnim;
	public Animator slideMenuAnim;

	public void StartGame () 
	{
		SceneManager.LoadScene ("FG_MappaP_01");
	}

	public void OpenSettings()
	{
		startButtonAnim.SetBool ("IsHidden", true);
		settingsButtonAnim.SetBool ("isHidden", true);
		settingsPanelAnim.SetBool ("IsHidden", false);
	}

	public void CloseSettings()
	{
		startButtonAnim.SetBool ("IsHidden", false);
		settingsButtonAnim.SetBool ("isHidden", false);
		settingsPanelAnim.SetBool ("IsHidden", true);
	}

	public void slideMenuUp()
	{
		bool isHidden = slideMenuAnim.GetBool ("isHidden");
		slideMenuAnim.SetBool ("isHidden", !isHidden);
	}

}