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
            Debug.Log("Make Decision");
            decisionMaker.MakeDecision();
        }
    }
}
