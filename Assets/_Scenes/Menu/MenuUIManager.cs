using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuUIManager : MonoBehaviour
{
	public GameObject mainMenu; // Main Menu
	public GameObject settingsMenu; // Settings Menu
	public GameObject audioMenu; // Audio Menu
    public GameObject videoMenu; // Video Menu
    public GameObject controllerMenu; // Controller Menu
    public GameObject selectLevelMenu; // Select Level Menu
    public GameObject exitMenu; // Exit Menu
    public GameObject areYouSure; // Security menu which appear only if there is a save file. In case of missing save file, it's doesn't appear
    public GameObject continueButton; // Button which allow users to continue previously game
    public EventSystem eventSystem; // The Event System
    public GameObject firstSelectedMainMenuButton; // First button selected in the Main Menu
    public GameObject firstSelectedSettingsMenuButton; // First button selected in the Settings Menu
    public GameObject firstSelectedAudioMenuButton; // First button selected in the Audio Menu
    public GameObject firstSelectedVideoMenuButton; // First button selected in the Video Menu
    public GameObject firstSelectedControllerMenuButton; // First button selected in the Controller Menu
    public GameObject firstSelectedSelectLevelMenuButton; // First button selected in the Select Level Menu
    public GameObject firstSelectedExitMenuButton; // First button selected in the Exit Menu
    public GameObject firstSelectedAreYouSureButton; // First button selected in the "Security Menu"
    public int variabileCheckMenu; // Variable that allow to appear the "Security Menu" or not
    public Button areYouSureYesButton; // The "Yes Button" in the "Security Menu"
    public Button areYouSureNoButton; // The "No Button" in the "Security Menu"
    public Button newGameButton; // The New Game Button in the Main Menu
    public Button selectLevelMenuButton; // The Select Level Menu Button in the Main Menu
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
		if (GameController.getlastScene() > 1) // If there is a save file, allow the "Continue Button" to appear in the Main Menu
			continueButton.SetActive (true);
        else // If there is not a save file, the "Continue Button" will not appear in the Main Menu
            continueButton.SetActive (false);
	}	

	public void StartNewGame() // Start new game function
	{
		SceneManager.LoadSceneAsync (2);
	}

	public void FadesMenu(string menuType) // Set the time to wait until the fade animation is finished
	{
		Invoke (menuType, 0.2f);
	}

	public void SettingsMenu()// Enabled the Settings Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (true);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedSettingsMenuButton); // Set the first selected button in the menu
	}

	public void MainMenu() // Enabled the Main Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (true);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton); // Set the first selected button in the menu
        variabileCheckMenu = 0;
	}

	public void AudioMenu() // Enabled the Audio Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (true);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedAudioMenuButton); // Set the first selected button in the menu
    }

	public void VideoMenu() // Enabled the Video Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (true);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedVideoMenuButton); // Set the first selected button in the menu
    }

	public void ControllerMenu() // Enabled the Controller Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (true);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton); // Set the first selected button in the menu
    }

	public void Continue() // Load the previous game
	{
		GC.LoadLastScene ();
	}

	public void SelectLevelMenu() // Enabled the Select Level Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (true);
		exitMenu.gameObject.SetActive (false);
		areYouSure.gameObject.SetActive (false);
        eventSystem.SetSelectedGameObject(firstSelectedSelectLevelMenuButton); // Set the first selected button in the menu
    }

	public void ExitGameMenu() // Enabled the Exit Game Menu and disable all the others
	{
		mainMenu.gameObject.SetActive (false);
		settingsMenu.gameObject.SetActive (false);
		audioMenu.gameObject.SetActive (false);
		videoMenu.gameObject.SetActive (false);
		controllerMenu.gameObject.SetActive (false);
		selectLevelMenu.gameObject.SetActive (false);
		exitMenu.gameObject.SetActive (true);
		areYouSure.gameObject.SetActive (false);
		eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton); // Set the first selected button in the menu
    }

	public void ExitGameYes() // Exit game
	{
		Application.Quit();
	}

	public void NewGameButtonVariabileCheckMenu () // When the user press the "New Game Button", set the variable to 1 
	{
		variabileCheckMenu = 1;
	}

	public void LevelVariabileCheckMenu () // When the user press the "Level Button", set the variable to 2
    {
		variabileCheckMenu = 2;
	}

    public void SelectLevelMenuVariabileCheckMenu() // When the user press the "Select Level Menu Button", set the variable to 3
    {
        variabileCheckMenu = 3;
    }

    public void AreYouSure()
	{
        if (GameController.getlastScene() > 1)) // If there is a save file, it allow to appear the "Security menu"
            { 
		areYouSure.gameObject.SetActive (true); // Show the "Secury Menu"
		eventSystem.SetSelectedGameObject(firstSelectedAreYouSureButton); // Set the first selected button in the menu
            if (variabileCheckMenu == 1) // If the "Security Menu" appears after the user has pressed the "New Game Button", the game will allow the user to star a New Game if he has pressed "Yes" and came back to the Main Menu if he has pressed "No"
		{
			areYouSureYesButton.onClick.AddListener(StartNewGame);
			areYouSureNoButton.onClick.AddListener(MainMenu);
		}
		if (variabileCheckMenu == 2) // If the "Security Menu" appears after the user has pressed the "Level Button", the game will allow the user to star a the level if he has pressed "Yes" and came back to the "Select Level menu" if he has pressed "No"
            {
			//areYouSureYesButton.onClick.AddListener(SelectLevelMenu);
			//areYouSureNoButton.onClick.AddListener(SelectLevelMenu);

			areYouSureNoButton.onClick.AddListener(SelectLevelMenu); // Set the first selected button in the menu
            }
            else // If there is not a save file, it doesn't allow to appear the "Security menu"
            {
                if (variabileCheckMenu == 1) // If the "Security Menu" doesn't have to appear, after the user has pressed the "New Game Button", the game will star a New Game
                {
                    newGameButton.onClick.AddListener(StartNewGame);
                }
                if (variabileCheckMenu == 3) // If the "Security Menu" doesn't have to appear, after the user has pressed the "Select Level Menu Button", the game will open the "Select Level Menu" 
                {
                    selectLevelMenuButton.onClick.AddListener(SelectLevelMenu);
                }
			
	}
		
}