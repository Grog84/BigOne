using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class TaskTool : MonoBehaviour
    {
        public enum TaskType { GUARD_IS_ALARMED, GUARD_IS_CHAR_VISIBLE, GUARD_CHAR_CHASE }
        public TaskType taskType;

        public Task GetTask()
        {
            switch (taskType)
            {
                case TaskType.GUARD_IS_ALARMED:
                    return new ConditionAlarmed();
                case TaskType.GUARD_IS_CHAR_VISIBLE:
                    return new ConditionPlayerVisible();
                case TaskType.GUARD_CHAR_CHASE:
                    return new ActionChase();
                default:
                    return null;
            }
        }
	
    }

}
