using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    [CreateAssetMenu(menuName = "AI/BTDM")]

    public class BehaviourTreeDM : DecisionMaker
    {
        // Blackboard Area
        // ...

        public Task rootTask;

        //void Start()
        //{
        //    // Build the tree from game objects

        //    //rootTask = GetComponent<Task>();
        //    //BuildTree(rootTask);
        //}

        public void AssignRootTask(Task rTask)
        {
            rootTask = rTask;
        }

        //public void BuildTree(Task parentTask)
        //{
        //    //parentTask.m_Agent = GetComponent<Agent>();
        //    //parentTask.btdm = this;

        //    //if (parentTask.transform.childCount > 0)
        //    //{
        //    //    // This is a composite task
        //    //    Composite composite = parentTask as Composite;
        //    //    composite.children = new List<Task>();

        //    //    foreach (Transform child in composite.transform)
        //    //    {
        //    //        Task childTask = child.GetComponent<Task>();
        //    //        composite.children.Add(childTask);
        //    //        BuildTree(childTask);
        //    //    }
        //    //}
        //}

        public void PrintTree(int i, Task parentTask)
        {
            if (i == 0)
            {
                Composite rtask = rootTask as Composite;
                Debug.Log("Livello : " + i);
                Debug.Log(rtask.ToString());
                i++;
                foreach (var tsk in rtask.children)
                {
                    PrintTree(i, tsk);
                }

            }

            Composite pTask = parentTask as Composite;

            foreach (var tsk in pTask.children)
            {
                Debug.Log("Livello : " + i);
                Debug.Log(tsk.ToString());

                Composite thisTsk = tsk as Composite;
                if (thisTsk.children != null)
                    PrintTree(i + 1, tsk);

            }
        }

        public override void MakeDecision()
        {
            rootTask.Run();
        }
    }
}

