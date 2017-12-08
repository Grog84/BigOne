using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionQuestNotCompleted : Task
    {
        public override TaskState Run()
        {
            //trigger animazione di NO
            return TaskState.SUCCESS;
        }
    }
}