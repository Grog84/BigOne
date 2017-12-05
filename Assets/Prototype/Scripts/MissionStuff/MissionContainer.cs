using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace MissionManagerStuff
{
    [Serializable]
    public class MissionContainer
    {          
        public List<Mission> MissionList= new List<Mission>();
   
    }
}

