using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System.Collections.Generic;


namespace MissionManagerStuff
{
    [Serializable]
    [ShowOdinSerializedPropertiesInInspector]
   
    public class MissionContainer
    {

   
        public List<Mission> MissionList= new List<Mission>();

    }
}

