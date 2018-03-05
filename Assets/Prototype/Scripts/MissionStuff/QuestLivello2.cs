using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestManager
{

    public class QuestLivello2 : MonoBehaviour {

        public enum STATUSLEVELO2
        {
            Objective1, Objective2, Objective3, Objective4, Objective5, Objective6, Objective7, Objective8
        }

        STATUSLEVELO2 Level2;
        // Use this for initialization
        void Start() {
            Level2 = STATUSLEVELO2.Objective1;
            Text = GameObject.Find("ObjectiveName");
         
        }
        GameObject Text;
        // Update is called once per frame
        void Update() {
            switch (Level2)
            {
                case STATUSLEVELO2.Objective1:
                    Text.GetComponent<Text>().text = "Talk to your neighbour";
                    break;
                case STATUSLEVELO2.Objective2:
                    Text.GetComponent<Text>().text = "Bring lunch to your neighbour’s husband";
                    break;
                case STATUSLEVELO2.Objective3:
                    Text.GetComponent<Text>().text = "Talk to the little girl";
                    break;
                case STATUSLEVELO2.Objective4:
                    Text.GetComponent<Text>().text = "Find the girl's toy";
                    break;
                case STATUSLEVELO2.Objective5:
                    Text.GetComponent<Text>().text = "Bring the toy to the girl";
                    break;
                case STATUSLEVELO2.Objective6:
                    Text.GetComponent<Text>().text = "Get to the park to find your son";
                    break;
                case STATUSLEVELO2.Objective7:
                    Text.GetComponent<Text>().text = "Hide from your mom!";
                    break;
                case STATUSLEVELO2.Objective8:
                    Text.GetComponent<Text>().text = "Find your hidden son";
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