using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.UI;

namespace AI.Tool
{
    public class StateHolder : MonoBehaviour
    {
        public State m_State;
        public Text m_Text;

        private void OnValidate()
        {
            m_Text.text = m_State.name;
        }

    }  

}

