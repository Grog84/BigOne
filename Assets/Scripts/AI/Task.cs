using System.Collections;
using UnityEngine;
//using AI.Movement;

namespace AI.BT
{
    public enum TaskState { FAILURE, SUCCESS, WAIT }

    public abstract class Task
    {
        public BehaviourTreeDM m_BehaviourTree;

        public abstract TaskState Run();
    }

}
