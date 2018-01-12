using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuUIManager : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Pause Menu
	public GameObject backToGameButton; // Back to the game button
	public GameObject controlsButton; // Controls Button
	public GameObject controlsImage; // Controls Image
	public GameObject backToMainMenu; // Back to main menu button
	public GameObject firstSelectedPauseMenuButton; // First button selected in the Main Menu
	public GameObject firstSelectedbackToMainMenu; // First button selected in the Back to game choice
    public GameObject diaryPanel; // Diary panel
	public GameObject diaryButton; // Diary Button
    public Button backToMainMenuYesButton; // The "Yes Button" in the "Security Menu"
    public Button backToMainMenuNoButton; // The "No Button" in the "Security Menu"
	public EventSystem eventSystem;
	public int variabilePauseMenu; // Variable that allow to the "AreYouSureMenu" what button has activated him;

    void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        pauseMenuPanel.gameObject.SetActive(true);
        backToGameButton.gameObject.SetActive(true);
        controlsButton.gameObject.SetActive(true);
		controlsImage.gameObject.SetActive (false);
        diaryButton.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
        diaryPanel.gameObject.SetActive(true);
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
		eventSystem.SetSelectedGameObject(firstSelectedPauseMenuButton);
    }

    public void BackToGame() // Back to game function
    {
        pauseMenuPanel.gameObject.SetActive(false); // Close the Pause Menu Panel
    }

    public void Controls() // Show the controls image
    {
        controlsImage.gameObject.SetActive(true); // Activate the controls image
		backToMainMenuYesButton.gameObject.SetActive(false);
		backToMainMenuNoButton.gameObject.SetActive(false);
		diaryPanel.gameObject.SetActive(false);
		variabilePauseMenu = 1;
    }

	public void FadesPauseMenu(string pauseMenuType) // Set the time to wait until the fade animation is finished
	{
		Invoke (pauseMenuType, 0.2f); // Enable the Fade 
		//switch (variabilePauseMenu) 
		/*{
		case 1: // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Main Menu"
			Invoke("MainMenu", 0.2f);
			break;
		case 2:
			Invoke("SelectLevelMenu", 0.2f); // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Select Level Menu"
			break;
		case 0:
			
			break;
		default:
			break;
		}*/
	}

	public void DiaryPanel()
	{
		controlsImage.gameObject.SetActive(false); // Activate the diary panel
		backToMainMenuYesButton.gameObject.SetActive(false);
		backToMainMenuNoButton.gameObject.SetActive(false);
		diaryPanel.gameObject.SetActive(true);
		variabilePauseMenu = 2;
	}

	public void BackToMainMenuChoice()// Enable the choice to go the Main Menu
    {
		eventSystem.SetSelectedGameObject(firstSelectedbackToMainMenu);
		backToMainMenuYesButton.gameObject.SetActive(true);
        backToMainMenuNoButton.gameObject.SetActive(true);
    }

    public void BackToMainMenuNO()// Close the choice to go the Main Menu
    {
		eventSystem.SetSelectedGameObject(firstSelectedPauseMenuButton);
		backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
		variabilePauseMenu = 3;
    }

    public void BackToMainMenuYes()// Go to the Main Menu
    {

    }

}
