using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class TaskTool : MonoBehaviour
    {
        public TaskType taskType;

        public Task GetTask()
        {
            Task thisTask;
            switch (taskType)
            {
                case TaskType.GUARD_ALARMED:
                    thisTask = new ActionAlarmed();
                    break;
                case TaskType.GUARD_CHAR_CHASE:
                    thisTask = new ActionChase();
                    break;
                case TaskType.GUARD_CHECK_NAVPOINT:
                    thisTask = new ActionCheckNavPoint();
                    break;
                case TaskType.GUARD_STOP:
                    thisTask = new ActionHoldPosition();
                    break;
                case TaskType.GUARD_PATROL:
                    thisTask = new ActionPatrol();
                    break;
                case TaskType.GUARD_RANDOM_PATROL:
                    thisTask = new ActionRandomPatrol();
                    break;
                case TaskType.GUARD_REACH_LAST_PERCIEVED_POSITION:
                    thisTask = new ActionReachLastPosition();
                    break;
                case TaskType.GUARD_WAIT_NAVPOINT:
                    thisTask = new ActionWaitNavPoint();
                    break;
                case TaskType.GUARD_IS_ALARMED:
                    thisTask = new ConditionAlarmed();
                    break;
                case TaskType.GUARD_IS_CURIOUS:
                    thisTask = new ConditionCurious();
                    break;
                case TaskType.GUARD_IS_WAITING:
                    thisTask = new ConditionIsWaiting();
                    break;
                case TaskType.GUARD_IS_LAST_PERCIEVED_POSITION_REACHED:
                    thisTask = new ConditionLastHeardSeenPosition();
                    break;
                case TaskType.GUARD_IS_LAST_NODE_REACHED:
                    thisTask = new ConditionLastNodeReached();
                    break;
                case TaskType.GUARD_IS_CHAR_VISIBLE:
                    thisTask = new ConditionPlayerVisible();
                    break;
                default:
                    thisTask = null;
                    break;
            }
            thisTask.m_Type = taskType;
            return thisTask;
            
        }
	
    }

}
