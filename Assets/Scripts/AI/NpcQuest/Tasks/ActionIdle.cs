using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ActionIdle : Task
    {
        public override TaskState Run()
        {
            //trigger animazione di idle
            return TaskState.SUCCESS;
        }
    }
}