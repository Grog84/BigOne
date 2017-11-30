using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUIManager : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject settingsMenu;
	public GameObject audioMenu;
	public GameObject videoMenu;
	public GameObject controllerMenu;
	public GameObject selectLevelMenu;
	public GameObject exitMenu;
	public GameObject areYouSure;
	public Button continueButton;
	public EventSystem eventSystem;
	public GameObject firstSelectedMainMenuButton;
	public GameObject firstSelectedSettingsMenuButton;
	public GameObject firstSelectedAudioMenuButton;
	public GameObject firstSelectedVideoMenuButton;
	public GameObject firstSelectedControllerMenuButton;
	public GameObject firstSelectedSelectLevelMenuButton;
	public GameObject firstSelectedExitMenuButton;
	public GameObject firstSelectedAreYouSureButton;

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
	{
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
	}	

	public void StartGame() //Start game function
	{
		SceneManager.LoadScene("FG_MappaP_01");
	}

	public void FadesMenu(string menuType) //Set the time to wait until the fade animation is finished
	{
		Invoke (menuType, 0.2f);
	}

	public void SettingsMenu()//Enabled the Settings Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (true);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedSettingsMenuButton);
	}

	public void MainMenu() //Enabled the Main Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
	}

	public void AudioMenu() //Enabled the Audio Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (true);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedAudioMenuButton);
	}

	public void VideoMenu() //Enabled the Video Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (true);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedVideoMenuButton);
	}

	public void ControllerMenu() //Enabled the Controller Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (true);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton);
	}

	public void Continue() //Load the previous game
	{

	}

	public void SelectLevelMenu() //Enabled the Select Level Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (true);
		exitMenu.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedSelectLevelMenuButton);
	}

	public void ExitGameMenu() //Enabled the Exit Game Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (true);
		eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton);
	}

	public void ExitGameYes() //Exit game
	{
		Application.Quit();
	}
		
}