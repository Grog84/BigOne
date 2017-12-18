using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace AI
{
    public class Brain : MonoBehaviour
    {
        [ReadOnly]
        public float tickDelay = 1;
        [ReadOnly]
        public float distance = 0f;

        public float shortRange = 100;
        public float shortRangeTickDelay = 0.2f;

        public float midRange = 200;
        public float midRangeTickDelay = 1f;

        public float longRange = 500;
        public float longRangeTickDelay = 5f;

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
                distance = (GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying].position - transform.position).sqrMagnitude;
                if (distance < 30)
                {
                    tickDelay = shortRangeTickDelay;
                }
                else if (distance >= 30 && distance < 100)
                {
                    tickDelay = midRangeTickDelay;
                }
                else
                    tickDelay = longRangeTickDelay;
            }
        }

        private void OnValidate()
        {
            if (midRange <= shortRange)
            {
                midRange = shortRange + 1;
            }

            if (longRange <= midRange)
            {
                longRange = midRange += 1;
            }

        }

    }
}
