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
        [HideInInspector] public STATUSLEVELO2 Level2;
        GameObject Text;
        public string[] objectivesDescription;
        public NpcQuestIcons[] myNpcs;

        void Start()
        {
            m_controller = GetComponent<_CharacterController>();
            Text = GameObject.Find("ObjectiveLvl1");
            updateState(STATUSLEVELO2.Objective1);
        }



        public void OnTriggerStay(Collider other)
        {
            if (Input.GetButton("Interact"))
            {
                if (other.name == "NpcInteraction")
                {

                    Debug.Log(other.transform.parent.name);
                    if (other.transform.parent.name == "NpcQuest (1)")
                    {
                        updateState(STATUSLEVELO2.Objective2);
                    }
                    if (other.transform.parent.name == "NpcQuest (2)")
                    {
                        updateState(STATUSLEVELO2.Objective3);
                    }
                    if (other.transform.parent.name == "Bambino")
                    {
                        if (Level2 == STATUSLEVELO2.Objective3)
                        {
                            updateState(STATUSLEVELO2.Objective4);
                        }
                        if (Level2 == STATUSLEVELO2.Objective5)
                        {
                            updateState(STATUSLEVELO2.Objective6);
                        }
                    }
                }
                if (other.name == "NotKey" && Level2 == STATUSLEVELO2.Objective4)
                {
                    updateState(STATUSLEVELO2.Objective5);
                }
            }
        }

        public void updateState(STATUSLEVELO2 newState)
        {
            if (newState == STATUSLEVELO2.Objective1)
            {
           
                Level2 = STATUSLEVELO2.Objective1;
                Text.GetComponent<Text>().text = objectivesDescription[0];
                myNpcs[0].isActive = true;
                myNpcs[1].isActive = false;
                myNpcs[2].isActive = false;
                updateIcions();

            }
            if (newState == STATUSLEVELO2.Objective2)
            {
                Level2 = STATUSLEVELO2.Objective2;
                Text.GetComponent<Text>().text = objectivesDescription[1];
                m_controller.isCarrying = true;
                myNpcs[0].isActive = false;
                myNpcs[1].isActive = true;
                myNpcs[2].isActive = false;
                updateIcions();

            }
            if (newState == STATUSLEVELO2.Objective3)
            {
                Level2 = STATUSLEVELO2.Objective3;
                Text.GetComponent<Text>().text = objectivesDescription[2];
                m_controller.isCarrying = false;
                myNpcs[0].isActive = false;
                myNpcs[1].isActive = false;
                myNpcs[2].isActive = true;
                updateIcions();

            }
            if (newState == STATUSLEVELO2.Objective4)
            {
                Level2 = STATUSLEVELO2.Objective4;
                Text.GetComponent<Text>().text = objectivesDescription[3];
                myNpcs[0].isActive = false;
                myNpcs[1].isActive = false;
                myNpcs[2].isActive = false;
                updateIcions();

            }
            if (newState == STATUSLEVELO2.Objective5)
            {
                Level2 = STATUSLEVELO2.Objective5;
                Text.GetComponent<Text>().text = objectivesDescription[4];
                myNpcs[0].isActive = false;
                myNpcs[1].isActive = false;
                myNpcs[2].isActive = true;
                updateIcions();
            }
            if (newState == STATUSLEVELO2.Objective6)
            {
                Level2 = STATUSLEVELO2.Objective6;
                Text.GetComponent<Text>().text = objectivesDescription[5];
                myNpcs[0].isActive = false;
                myNpcs[1].isActive = false;
                myNpcs[2].isActive = false;
                updateIcions();
            }
            if (newState == STATUSLEVELO2.Objective7)
            {
                Level2 = STATUSLEVELO2.Objective7;
                m_PlayableDirector.Play();

            }
        }

        void updateIcions()
        {
            for (int i = 0; i < myNpcs.Length; i++)
            {
                if(myNpcs[i].isActive)
                {
                    myNpcs[i].SetToObjective();
                }
                else
                {
                    myNpcs[i].HideIcons();
                }
            }
        }

    }
}