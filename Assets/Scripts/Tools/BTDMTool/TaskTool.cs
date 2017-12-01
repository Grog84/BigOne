using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class TaskTool : MonoBehaviour
    {
        public enum TaskType { GUARD_IS_ALARMED, GUARD_IS_CHAR_VISIBLE, GUARD_IS_CURIOUS, GUARD_IS_LAST_PERCIEVED_POSITION_REACHED, GUARD_IS_LAST_NODE_REACHED, GUARD_IS_WAITING,
                                GUARD_CHAR_CHASE, GUARD_ALARMED, GUARD_RANDOM_PATROL, GUARD_REACH_LAST_PERCIEVED_POSITION, GUARD_STOP, GUARD_CHECK_NAVPOINT, GUARD_WAIT_NAVPOINT, GUARD_PATROL}
        public TaskType taskType;

        public Task GetTask()
        {
            switch (taskType)
            {
                case TaskType.GUARD_ALARMED:
                    return new ActionAlarmed();
                case TaskType.GUARD_CHAR_CHASE:
                    return new ActionChase();
                case TaskType.GUARD_CHECK_NAVPOINT:
                    return new ActionCheckNavPoint();
                case TaskType.GUARD_STOP:
                    return new ActionHoldPosition();
                case TaskType.GUARD_PATROL:
                    return new ActionPatrol();
                case TaskType.GUARD_RANDOM_PATROL:
                    return new ActionRandomPatrol();
                case TaskType.GUARD_REACH_LAST_PERCIEVED_POSITION:
                    return new ActionReachLastPosition();
                case TaskType.GUARD_WAIT_NAVPOINT:
                    return new ActionWaitNavPoint();
                case TaskType.GUARD_IS_ALARMED:
                    return new ConditionAlarmed();
                case TaskType.GUARD_IS_CURIOUS:
                    return new ConditionCurious();
                case TaskType.GUARD_IS_WAITING:
                    return new ConditionIsWaiting();
                case TaskType.GUARD_IS_LAST_PERCIEVED_POSITION_REACHED:
                    return new ConditionLastHeardSeenPosition();
                case TaskType.GUARD_IS_LAST_NODE_REACHED:
                    return new ConditionLastNodeReached();
                case TaskType.GUARD_IS_CHAR_VISIBLE:
                    return new ConditionPlayerVisible();
                default:
                    return null;
            }
        }
	
    }

}
