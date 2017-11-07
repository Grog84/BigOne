using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.UI;

namespace AI.Tool
{
    public class ActionHolder : MonoBehaviour
    {
        public _Action m_Action;
        public Text m_Text;

        private void OnValidate()
        {
            m_Text.text = m_Action.name;
        }

    }  

}

