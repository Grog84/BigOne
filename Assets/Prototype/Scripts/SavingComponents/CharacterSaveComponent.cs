using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;

namespace SaveGame
{
    public class CharacterSaveComponent : SaveObjComponent
    {
        private CharacterStateController m_Controller;

        public override void Awake()
        {
            base.Awake();
            m_Controller = GetComponent<CharacterStateController>();

        }

        public override void LoadData()
        {
            base.LoadData();
            m_Controller.m_CharacterController.m_ForwardAmount = 0;

        }

        public override void SaveData()
        {
            base.SaveData();
        }
    }
}
