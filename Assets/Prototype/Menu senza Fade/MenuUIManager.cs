using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
	public GameObject mainMenu;
	public GameObject settingsMenu;
	public GameObject audioMenu;
	public GameObject videoMenu;
	public GameObject controllerMenu;
	public GameObject selectLevelMenu;
	public GameObject exitMenu;

	void Start() //Set on false all the object that has not to be on the main menu
	{
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}	

	public void StartGame() //Start game function
	{
		SceneManager.LoadScene("FG_MappaP_01");
	}

	public void FadesMenu(string menuType)
	{
		Invoke (menuType, 1);
	}

	public void SettingsMenu()//Put the settings option in the menu screen and and set on "False" all the other button and image
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (true);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}

	public void MainMenu() //Put the main menu in the menu screen and set on "False" all the other button and image
	{
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}

	public void AudioMenu() //Put in the screen the audio options and set on "False" all the other button and image
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (true);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}

	public void VideoMenu() //Put in the screen the video options and set on "False" all the other button and image
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (true);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}

	public void ControllerMenu() //Put in the screen the input layout and set on "False" all the other button and image
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (true);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
	}

	public void Continue() //Load the previous game
	{

	}

	public void SelectLevelMenu()
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (true);
		exitMenu.gameObject.SetActive (false);
	}

	public void ExitGameMenu() //Exit game function
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (true);
	}

	public void ExitGameYes()
	{
		Application.Quit();
	}
		
}