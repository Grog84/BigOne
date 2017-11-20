using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class ConditionAlarmed : Task
    {
        

        public override TaskState Run()
        {

            return TaskState.SUCCESS;
        }
    }
}