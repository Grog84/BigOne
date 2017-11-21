using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    [CreateAssetMenu(menuName = "AI/BTDM")]

    public class BehaviourTreeDM : DecisionMaker
    {

        public Task rootTask;

        public void AssignRootTask(Task rTask)
        {
            rootTask = rTask;
        }

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

