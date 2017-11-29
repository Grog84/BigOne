using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.SceneManagement;

namespace SaveGame
{
    public class GMSaveComponent : SaveObjComponent
    {

        private GMController m_Controller;

        public override void Awake()
        {
            m_Controller = GetComponent<GMController>();
        }

        public override void LoadData()
        {
            m_Controller.isCharacterPlaying = (CharacterActive)PlayerPrefs.GetInt(saveObjName + "characterPlaying");        
        }

        public override void SaveData()
        {
            CharacterActive activeCharacter = m_Controller.isCharacterPlaying;
            PlayerPrefs.SetInt(saveObjName + "characterPlaying", (int)activeCharacter);
        }
        public AT_Profile Profile;
        public void OnApplicationQuit()
        {
            //Profile.currentLevelIndex = SetLastScene();
            //ScreenCapture.CaptureScreenshot("ScreenInput.png");
#if !UNITY_EDITOR
          //  ScreenCapture.CaptureScreenshot("Assets/Prototype/Images/ScreenInput.png");
#endif
        }
        public static int SetLastScene()
        {
            int index;
            List<string> ignoreSceneName = new List<string> { "LG_MenuStart", "LG_Pause_Canvas","AT_ProvaASyncLoad"};
            bool checkIfNotMenuScene = true;
            for (int i = 0; i < ignoreSceneName.Count; i++)
            {
                if (SceneManager.GetActiveScene().name == ignoreSceneName[i])
                {
                    checkIfNotMenuScene = false;
                }
            }
            if (checkIfNotMenuScene)
            {
                return index = SceneManager.GetActiveScene().buildIndex;
              
            }
            else
            {
               return index = 0;
            
            }
        }
    }
}