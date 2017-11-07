using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateMachine;
using UnityEngine.UI;

namespace AI.Tool
{
    public class DecisionHolder : MonoBehaviour
    {
        public Decision m_Decision;
        public Text m_Text;

        private void OnValidate()
        {
            m_Text.text = m_Decision.name;
        }

    }  

}

