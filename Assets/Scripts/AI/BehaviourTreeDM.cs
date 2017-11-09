using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class BehaviourTreeDM : DecisionMaker
    {
        // Blackboard Area
        // ...

        Task rootTask;

        // Use this for initialization
        void Start()
        {
            // Build the tree from game objects

            rootTask = GetComponent<Task>();
            BuildTree(rootTask);
        }

        public void BuildTree(Task parentTask)
        {
            //parentTask.m_Agent = GetComponent<Agent>();
            //parentTask.btdm = this;

            if (parentTask.transform.childCount > 0)
            {
                // This is a composite task
                Composite composite = parentTask as Composite;
                composite.children = new List<Task>();

                foreach (Transform child in composite.transform)
                {
                    Task childTask = child.GetComponent<Task>();
                    composite.children.Add(childTask);
                    BuildTree(childTask);
                }
            }
        }

        public override void MakeDecision()
        {
            rootTask.Run();
        }
    }
}

