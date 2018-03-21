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
        [Space(10)]
        [MinMaxSlider(0, 200, true)]
        public Vector2 midRangeArea;
        [Space(10)]
        public float shortRangeTickDelay = 0.2f;
        float shortRangeSQ;

        public float midRangeTickDelay = 1f;

        public float longRangeTickDelay = 5f;
        float longRangeSQ;

        public DecisionMaker decisionMaker;

        [HideInInspector] public bool brainActive;

        void Start()
        {
            brainActive = true;
            StartCoroutine(BrainCO());
            shortRangeSQ = midRangeArea.x * midRangeArea.x;
            longRangeSQ = midRangeArea.y * midRangeArea.y;
        }

        public IEnumerator BrainCO()
        {
            while (true)
            {
                //Debug.Log("Thinking? " + brainActive);
                yield return new WaitForSeconds(tickDelay);
                if(brainActive)
                    TickBrain();
            }
        }

        void TickBrain()
        {
            //Debug.Log("Thinking");
            decisionMaker.MakeDecision();
            UpdateTickDelay();
        }

        void UpdateTickDelay()
        {
            
            if (GMController.instance.isCharacterPlaying == CharacterActive.Boy || GMController.instance.isCharacterPlaying == CharacterActive.Mother)
            {
                distance = (GMController.instance.playerTransform[(int)GMController.instance.isCharacterPlaying].position - transform.position).sqrMagnitude;
                if (distance < shortRangeSQ)
                {
                    tickDelay = shortRangeTickDelay;
                }
                else if (distance >= shortRangeSQ && distance < longRangeSQ)
                {
                    tickDelay = midRangeTickDelay;
                }
                else
                    tickDelay = longRangeTickDelay;
            }
        }

    }
}
