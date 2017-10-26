using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace SaveGame
{
    public class GMSaveComponent : SaveObjComponent
    {

        private GMController m_Controller;

        private void Awake()
        {
            m_Controller = GetComponent<GMController>();
        }

        public override void LoadData()
        {
            CharacterActive activeCharacter = (CharacterActive)PlayerPrefs.GetInt(saveObjName + "characterPlaying");
        }

        public override void SaveData()
        {
            CharacterActive activeCharacter = m_Controller.isCharacterPlaying;
            PlayerPrefs.SetInt(saveObjName + "characterPlaying", (int)activeCharacter);
        }
    }
}