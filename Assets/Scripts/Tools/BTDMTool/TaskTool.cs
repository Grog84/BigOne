using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.BT
{
    public class TaskTool : MonoBehaviour
    {
        public TaskType taskType;
        BTDMStringConverter converter = new BTDMStringConverter();

        public Task GetTask()
        {
            Task thisTask;
            thisTask = converter.InstantiateTask(taskType);
            thisTask.m_Type = taskType;
            return thisTask; 
        }

        public Task GetTask(TaskType taskType)
        {
            Task thisTask;
            thisTask = converter.InstantiateTask(taskType);
            thisTask.m_Type = taskType;
            return thisTask;
        }

        
    }

}
