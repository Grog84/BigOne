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
	public GameObject firstSelectedBackToMainMenu; // First button selected in the Back to game choice
    public GameObject diaryPanel; // Diary panel
	public GameObject diaryButton; // Diary Button
    public Button backToMainMenuYesButton; // The "Yes Button" in the "Security Menu"
    public Button backToMainMenuNoButton; // The "No Button" in the "Security Menu"
	public EventSystem eventSystem;

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
        diaryPanel.gameObject.SetActive(false);
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
    }

	public void FadesPauseMenu(string pauseMenuType) // Set the time to wait until the fade animation is finished
	{
		Invoke (pauseMenuType, 0.2f); // Enable the Fade 
	}

	public void DiaryPanel()
	{
		controlsImage.gameObject.SetActive(false); // Activate the diary panel
        diaryPanel.gameObject.SetActive(true);
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
    }

	public void BackToMainMenuChoice()// Enable the choice to go the Main Menu
    {
		eventSystem.SetSelectedGameObject(firstSelectedBackToMainMenu);
        backToMainMenuYesButton.gameObject.SetActive(true);
        backToMainMenuNoButton.gameObject.SetActive(true);
    }

    public void BackToMainMenuNO()// Close the choice to go the Main Menu
    {
		eventSystem.SetSelectedGameObject(firstSelectedPauseMenuButton);
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
        controlsImage.gameObject.SetActive(false);
        diaryPanel.gameObject.SetActive(true);
    }

    public void BackToMainMenuYes()// Go to the Main Menu
    {

    }

}
