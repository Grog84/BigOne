using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveGame
{
    public class DoorSaveComponent : SaveObjComponent
    {

        private Doors m_Door;

        private void Awake()
        {
            m_Door = GetComponent<Doors>();
        }

        public override void LoadData()
        {
            base.LoadData();
            int status = PlayerPrefs.GetInt(saveObjName + "DoorStatus");
            if (status == 0)
                m_Door.isDoorOpen = false;
            else
                m_Door.isDoorOpen = true;
        }

        public override void SaveData()
        {
            base.SaveData();
            PlayerPrefs.SetInt(saveObjName + "DoorStatus", m_Door.isDoorOpen ? 1 : 0);
        }
    }
}
