using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    public class Brain : MonoBehaviour
    {
        public float tickDelay = 1;
        public DecisionMaker decisionMaker;

        void Start()
        {
            InvokeRepeating("TickBrain", tickDelay, tickDelay);
        }

        void TickBrain()
        {
            decisionMaker.MakeDecision();
            UpdateTickDelay();
        }

        void UpdateTickDelay()
        {
            if (GMController.instance.isCharacterPlaying == CharacterActive.Boy || GMController.instance.isCharacterPlaying == CharacterActive.Mother)
            {
                float distance = (GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying].position - transform.position).sqrMagnitude;
                if (distance < 30)
                {
                    tickDelay = 0.3f;
                }
                else if (distance >= 30 && distance < 100)
                {
                    tickDelay = 1f;
                }
                else
                    tickDelay = 5f;
            }
        }

    }
}
