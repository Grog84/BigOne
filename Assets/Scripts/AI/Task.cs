using System.Collections;
using UnityEngine;
//using AI.Movement;

namespace AI.BT
{
    public enum TaskState { FAILURE, SUCCESS, WAIT }

    [System.Serializable]
    public abstract class Task : ScriptableObject
    {
        public BehaviourTreeDM m_BehaviourTree;
        public TaskType m_Type;

        public abstract TaskState Run();

        public override string ToString()
        {
            string printOut = base.ToString() + " My tree: " + m_BehaviourTree.ToString();
            return printOut;
        }
    }

}
