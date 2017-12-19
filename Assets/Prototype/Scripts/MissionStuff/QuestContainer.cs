using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace QuestManager
{
    [Serializable]
    [CreateAssetMenu(menuName ="Prototype/QuestContainer")]
    public class QuestContainer:ScriptableObject
    {          
        public List<Quest> QuestList= new List<Quest>();
   
    }
}

