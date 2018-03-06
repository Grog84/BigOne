using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Character;

namespace QuestManager
{

    public class QuestLivello2 : CutsceneManager
    {
        _CharacterController m_controller;
        public enum STATUSLEVELO2 { Objective1, Objective2, Objective3, Objective4, Objective5, Objective6, Objective7, Objective8 }
        [HideInInspector]public STATUSLEVELO2 Level2;
        GameObject Text;
        public string[] objectivesDescription;

        void Start()
        {
            m_controller = GetComponent<_CharacterController>();
            Level2 = STATUSLEVELO2.Objective1;
            Text = GameObject.Find("ObjectiveLvl1");
        }
        

        void Update() {
            switch (Level2)
            {
                case STATUSLEVELO2.Objective1:
                    Text.GetComponent<Text>().text = objectivesDescription[0];
                    break;
                case STATUSLEVELO2.Objective2:
                    Text.GetComponent<Text>().text = objectivesDescription[1];
                    m_controller.isCarrying = true;
                    break;
                case STATUSLEVELO2.Objective3:
                    Text.GetComponent<Text>().text = objectivesDescription[2];
                    m_controller.isCarrying = false;
                    break;
                case STATUSLEVELO2.Objective4:
                    Text.GetComponent<Text>().text = objectivesDescription[3];
                    break;
                case STATUSLEVELO2.Objective5:
                    Text.GetComponent<Text>().text = objectivesDescription[4];
                    break;
                case STATUSLEVELO2.Objective6:
                    Text.GetComponent<Text>().text = objectivesDescription[5];
                    break;
                case STATUSLEVELO2.Objective7:
                    m_PlayableDirector.Play();
                    break;
               
            }
           
         
        }



        public void OnTriggerStay(Collider other)
        {
            if(Input.GetButton("Interact"))
            {
                if(other.name== "NpcInteraction")
                {
                    Debug.Log(other.transform.parent.name);
                    if(other.transform.parent.name == "NpcQuest (1)") 
                    {
                        Level2 = STATUSLEVELO2.Objective2;
                    }
                    if (other.transform.parent.name == "NpcQuest (2)")
                    {
                        Level2 = STATUSLEVELO2.Objective3;
                    }
                    if (other.transform.parent.name == "Bambino")
                    {
                        if (Level2 == STATUSLEVELO2.Objective3)
                        {
                            Level2 = STATUSLEVELO2.Objective4;
                        }
                        if(Level2== STATUSLEVELO2.Objective5)
                        {
                            Level2 = STATUSLEVELO2.Objective6;
                        }
                    }
                }
                if(other.name== "NotKey")
                {
                    Level2 = STATUSLEVELO2.Objective5;
                }
            }
        }
    }
}