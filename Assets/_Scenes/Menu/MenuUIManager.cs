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
	public GameObject continueButton;
	public EventSystem eventSystem;
	public GameObject firstSelectedMainMenuButton;
	public GameObject firstSelectedSettingsMenuButton;
	public GameObject firstSelectedAudioMenuButton;
	public GameObject firstSelectedVideoMenuButton;
	public GameObject firstSelectedControllerMenuButton;
	public GameObject firstSelectedSelectLevelMenuButton;
	public GameObject firstSelectedExitMenuButton;
	public GameObject firstSelectedAreYouSureButton;
	public int variabileCheckMenu;
	public Button areYouSureYesButton;
	public Button areYouSureNoButton;
	private GameController GC;

	void Start() //Disable all the GameObject-Menu that has not to be on the screen
	{
		GC = FindObjectOfType<GameController> ().GetComponents<GameController> ();
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
		variabileCheckMenu = 0;
		if (GameController.getlastScene() > 1) 
			continueButton.SetActive (true);
		else 
			continueButton.SetActive (false);
	}	

	public void StartNewGame() //Start game function
	{
		SceneManager.LoadSceneAsync (2);
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
		areYouSure.gameObject.SetActive (false);
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
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
		variabileCheckMenu = 0;
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
		areYouSure.gameObject.SetActive (false);
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
		areYouSure.gameObject.SetActive (false);
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
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton);
	}

	public void Continue() //Load the previous game
	{
		GC.LoadLastScene ();
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
		areYouSure.gameObject.SetActive (false);
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
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton);
	}

	public void ExitGameYes() //Exit game
	{
		Application.Quit();
	}

	public void NewGameButtonVariabileCheckMenu ()
	{
		variabileCheckMenu = 1;
	}

	public void SelectLevelMenuVariabileCheckMenu ()
	{
		variabileCheckMenu = 2;
	}

	public void AreYouSure()
	{
		areYouSure.gameObject.SetActive (true);
		eventSystem.SetSelectedGameObject(firstSelectedAreYouSureButton);
		if (variabileCheckMenu == 1) 
		{
			areYouSureYesButton.onClick.AddListener(StartNewGame);
			areYouSureNoButton.onClick.AddListener(MainMenu);
		}
		if (variabileCheckMenu == 2) 
		{
			//areYouSureYesButton.onClick.AddListener(SelectLevelMenu);
			//areYouSureNoButton.onClick.AddListener(SelectLevelMenu);

			areYouSureNoButton.onClick.AddListener(SelectLevelMenu);
		}
			
	}
		
}