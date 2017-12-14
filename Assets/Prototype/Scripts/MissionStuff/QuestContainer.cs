using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace QuestManager
{
    [Serializable]
    public class QuestContainer
    {          
        public List<Quest> MissionList= new List<Quest>();
   
    }
}

