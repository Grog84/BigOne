using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenuUIManager : MonoBehaviour
{
    public GameObject pauseMenuPanel; // Pause Menu
    public Button backToGameButton; // Back to the game button
    public Button controlsButton; // Controls Button
    public GameObject controlsPanel; // Controls Panel
    public Button backToMainMenu; // Back to main menu button
    public GameObject diaryPanel; // Diary panel
    public Button diaryButton; // Diary Button
    public Button backToMainMenuYesButton; // The "Yes Button" in the "Security Menu"
    public Button backToMainMenuNoButton; // The "No Button" in the "Security Menu"

    void Start() //Disable all the GameObject-Menu that has not to be on the screen
    {
        pauseMenuPanel.gameObject.SetActive(true);
        backToGameButton.gameObject.SetActive(true);
        controlsButton.gameObject.SetActive(true);
        controlsPanel.gameObject.SetActive(false);
        diaryButton.gameObject.SetActive(true);
        backToMainMenu.gameObject.SetActive(true);
        diaryPanel.gameObject.SetActive(true);
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
    }

    public void BackToGame() // Back to game function
    {
        pauseMenuPanel.gameObject.SetActive(false); // Close the Pause Menu Panel
    }

    public void Controls() // Show the controls image
    {
        controlsPanel.gameObject.SetActive(true); // Activate the controls panel
    }

    // public void FadesPauseMenu(string menuType) // Set the time to wait until the fade animation is finished
    // {
    //	switch (variabileCheckAreYouSure) 
    //{
    //case 1: // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Main Menu"
    //	Invoke("MainMenu", 0.2f);
    //break;
    //case 2:
    //Invoke("SelectLevelMenu", 0.2f); // Enable the Fade when the user press the "No Button" in the "AreYouSureMenu" and let him go back to the "Select Level Menu"
    //break;
    //case 0:
    //Invoke(menuType, 0.2f); // Enable the Fade 
    //break;
    //default:
    //break;
    //}
    //}

    public void BackToMainMenuChoice()// Enable the choice to go the Main Menu
    {
        backToMainMenuYesButton.gameObject.SetActive(true);
        backToMainMenuNoButton.gameObject.SetActive(true);
    }

    public void BackToMainMenuNO()// Close the choice to go the Main Menu
    {
        backToMainMenuYesButton.gameObject.SetActive(false);
        backToMainMenuNoButton.gameObject.SetActive(false);
    }

    public void BackToMainMenuYes()// Go to the Main Menu
    {

    }

}
