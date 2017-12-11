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
	public int variabileCheckAreYouSure; // Variable that allow to the "AreYouSureMenu" what button has activated him;
	public Button areYouSureYesButton; // The "Yes Button" in the "Security Menu"
    public Button areYouSureNoButton; // The "No Button" in the "Security Menu"
    private SaveManager SM;

	// FINTA VARIABILE INT DI LIVELLI SBLOCCATI

    void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        SM = FindObjectOfType<SaveManager>();
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton);
//        variabileCheckMenu = 0;
		if (SaveManager.getlastScene() > 1) // If there is a save file, allow the "Continue Button" to appear in the Main Menu
            continueButton.SetActive(true);
        else // If there is not a save file, the "Continue Button" will not appear in the Main Menu
            continueButton.SetActive(false);

        inizialize();
        // CONTROLLO SUYI BOTTONI DA ATTIVARE
        // FOR (BOTTONI)
        //     DEACTIVATE BOTTONI NON BUONI

        Button btn = areYouSureNoButton.GetComponent<Button>();
    }

	public void StartNewGame() // Start new game function
	{
		SceneManager.LoadSceneAsync(1);
	}

	public void NewGameButton() // Start new game button function
    {
		variabileCheckAreYouSure = 1;
		if (SaveManager.getlastScene () > 1) {
			AreYouSure ();
		} else
			StartNewGame ();
    }

    public void FadesMenu(string menuType) // Set the time to wait until the fade animation is finished
    {
		switch (variabileCheckAreYouSure) 
		{
		case 1: // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Main Menu"
			Invoke("MainMenu", 0.2f);
			break;
		case 2:
			Invoke("SelectLevelMenu", 0.2f); // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Select Level Menu"
			break;
		case 0:
			Invoke (menuType, 0.2f); // Enable the Fade 
			break;
		default:
			break;
		}
    }

    public void SettingsMenu()// Enabled the Settings Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(true);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedSettingsMenuButton); // Set the first selected button in the menu
    }

    public void MainMenu() // Enabled the Main Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(true);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedMainMenuButton); // Set the first selected button in the menu
		variabileCheckAreYouSure = 0;
	}

    public void AudioMenu() // Enabled the Audio Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(true);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedAudioMenuButton); // Set the first selected button in the menu
    }

    public void VideoMenu() // Enabled the Video Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(true);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedVideoMenuButton); // Set the first selected button in the menu
    }

    public void ControllerMenu() // Enabled the Controller Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(true);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedControllerMenuButton); // Set the first selected button in the menu
    }

    public void Continue() // Load the previous game
    {
        SM.LoadLastScene();
    }

	public void SelectLevelMenu() // Enabled the Select Level Menu and disable all the others
    {
		//variabileCheckAreYouSure = 2;
		variabileCheckAreYouSure = 0;
		mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(true);
        exitMenu.gameObject.SetActive(false);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedSelectLevelMenuButton); // Set the first selected button in the menu
   
    }

    public void ExitGameMenu() // Enabled the Exit Game Menu and disable all the others
    {
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        audioMenu.gameObject.SetActive(false);
        videoMenu.gameObject.SetActive(false);
        controllerMenu.gameObject.SetActive(false);
        selectLevelMenu.gameObject.SetActive(false);
        exitMenu.gameObject.SetActive(true);
        areYouSure.gameObject.SetActive(false);
        eventSystem.SetSelectedGameObject(firstSelectedExitMenuButton); // Set the first selected button in the menu
    }

    public void ExitGameYes() // Exit game
    {
        Application.Quit();
    }

	public void SelectLevelButtonCheck()
	{
		if (SaveManager.getlastScene () > 1) 
		{
			variabileCheckAreYouSure = 2;
			AreYouSure ();
		}
	}
			
	public void AreYouSure()
    {
		//mainMenu.gameObject.SetActive(false);
		settingsMenu.gameObject.SetActive(false);
		audioMenu.gameObject.SetActive(false);
		videoMenu.gameObject.SetActive(false);
		controllerMenu.gameObject.SetActive(false);
		//selectLevelMenu.gameObject.SetActive(false);
		exitMenu.gameObject.SetActive(false);
		areYouSure.gameObject.SetActive(true);
		eventSystem.SetSelectedGameObject(firstSelectedAreYouSureButton); // Set the first selected button in the menu
		switch (variabileCheckAreYouSure) 
		{
		case 1:
			mainMenu.gameObject.SetActive (true);
			areYouSureYesButton.onClick.AddListener (StartNewGame);
			break;
		case 2:
			selectLevelMenu.gameObject.SetActive(true);
			//areYouSureNoButton.onClick.AddListener (SelectLevelMenu);
			break;
		default:
			break;
		}
	}
    public Button[] LevelSelect;

    public void inizialize()
    {
        LevelSelect = new Button[9];

        #region findChildStuff
        LevelSelect[0] = selectLevelMenu.transform.Find("SelectLevel1Button").GetComponent<Button>();
        LevelSelect[1] = selectLevelMenu.transform.Find("SelectLevel2Button").GetComponent<Button>();
        LevelSelect[2] = selectLevelMenu.transform.Find("SelectLevel3Button").GetComponent<Button>();
        LevelSelect[3] = selectLevelMenu.transform.Find("SelectLevel4Button").GetComponent<Button>();
        LevelSelect[4] = selectLevelMenu.transform.Find("SelectLevel5Button").GetComponent<Button>();
        LevelSelect[5] = selectLevelMenu.transform.Find("SelectLevel6Button").GetComponent<Button>();
        LevelSelect[6] = selectLevelMenu.transform.Find("SelectLevel7Button").GetComponent<Button>();
        LevelSelect[7] = selectLevelMenu.transform.Find("SelectLevel8Button").GetComponent<Button>();
        LevelSelect[8] = selectLevelMenu.transform.Find("SelectLevel9Button").GetComponent<Button>();
        #endregion


        for (int i = 0; i < 9; i++)
        {
            if(SM.Profile.completedLevel[i])
            {
                LevelSelect[i].enabled = true;

            }
            else
            {
                LevelSelect[i].enabled = false;
            }
        }
        
        Debug.Log(LevelSelect.Length + "," + this.selectLevelMenu.transform.childCount);
    }










}