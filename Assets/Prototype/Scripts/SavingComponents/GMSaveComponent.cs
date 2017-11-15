using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

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
        public void OnApplicationQuit()
        {
            //ScreenCapture.CaptureScreenshot("ScreenInput.png");
#if !UNITY_EDITOR
            ScreenCapture.CaptureScreenshot("Assets/Prototype/Images/ScreenInput.png");
#endif
        }
    }
}