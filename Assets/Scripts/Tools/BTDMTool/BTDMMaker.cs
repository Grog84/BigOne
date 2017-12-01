using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.BT;
using AI;
using System.Linq;

public class BDTMJsonConverter
{
    public BehaviourTreeDM m_Tree;
    public string m_Code;

    public string TaskToCode(Task task, string prefixCode)
    {
        string taskCode = "";
        if (task.m_Type == TaskType.SELECTOR)
        {
            taskCode = "S";
        }
        else if (task.m_Type == TaskType.SEQUENCER)
        {
            taskCode = "Q";
        }
        else
        {
            taskCode = "T";
            taskCode += task.m_Type;
        }

        string code = prefixCode + taskCode + ";\n";
        return code;
    }

    public void ConvertToCode(Task task, string prefixCode)
    {
        string taskToCode = TaskToCode(task, prefixCode);

        m_Code = m_Code + taskToCode;
        if (task.m_Type == TaskType.SELECTOR || task.m_Type == TaskType.SEQUENCER)
        {
            var cmptask = (Composite)task;
            int i = 0;
            foreach (var tsk in cmptask.children)
            {
                string childPrefix = taskToCode.Substring(0, taskToCode.Length - 3) + i.ToString();
                ConvertToCode(tsk, childPrefix);
                i++;
            }
        }
    }

    public void WriteTree()
    {
        m_Code = "";
        ConvertToCode(m_Tree.rootTask, "0");
        Debug.Log(m_Code);
    }
    
}

public class BTDMMaker : MonoBehaviour {

    public BehaviourTreeDM behaviourTree;
    public GameObject rootTask;

    [SerializeField]
    public Blackboard thisBlackboard;

    public enum AgentType { GUARD }
    public AgentType thisAgentType = AgentType.GUARD;

    public GameObject selector;
    public GameObject sequencer;
    public GameObject task;

    private void BuildTree(GameObject thisToolTask, Task thisTask)
    {

        if (thisToolTask.transform.childCount > 0)
        {
            var parentTask = thisTask as Composite;
            parentTask.children = new List<Task>();

            foreach (Transform tr in thisToolTask.transform)
            {
                Task task = null;
                if (tr.gameObject.tag == "ToolSequence")
                {
                    task = new Sequence();
                    task.m_Type = TaskType.SEQUENCER;
                }
                else if (tr.gameObject.tag == "ToolSelector")
                {
                    task = new Selector();
                    task.m_Type = TaskType.SELECTOR;
                }
                else
                {
                    task = tr.GetComponent<TaskTool>().GetTask();
                }

                task.m_BehaviourTree = behaviourTree;
                parentTask.children.Add(task);
                BuildTree(tr.gameObject, task);

            }
        }


    }

    private void AssignRoot()
    {
        if (rootTask.tag == "ToolSequence")
        {
            Sequence sequenceTask = new Sequence();
            sequenceTask.m_BehaviourTree = behaviourTree;
            sequenceTask.m_Type = TaskType.SEQUENCER;
            behaviourTree.AssignRootTask(sequenceTask);

        }
        else if (rootTask.tag == "ToolSelector")
        {
            Selector selectorTask = new Selector();
            selectorTask.m_BehaviourTree = behaviourTree;
            selectorTask.m_Type = TaskType.SELECTOR;
            behaviourTree.AssignRootTask(selectorTask);
        }
        else
        {
            Debug.Log("WHAT?!");
        }
    }

    private void AssignBlackboard()
    {
        switch (thisAgentType)
        {
            case AgentType.GUARD:
                
                var bl = new GuardBlackboard();
                Debug.Log(bl.ToString());

                behaviourTree.m_Blackboard = new GuardBlackboard();
                thisBlackboard = behaviourTree.m_Blackboard;
                break;
            default:
                break;
        }
    }

    public void PrintTree()
    {

        var converter = new BDTMJsonConverter();
        converter.m_Tree = behaviourTree;
        converter.WriteTree();

        //Debug.Log(rootTask.ToString());
        //Debug.Log(behaviourTree.m_Blackboard.ToString());
        //behaviourTree.PrintTree(0, behaviourTree.rootTask);
    }

    private void ShowConnections(GameObject thisTask)
    {
        if (thisTask.transform.childCount > 0)
        {
            foreach (Transform tr in thisTask.transform)
            {
                Debug.DrawLine(thisTask.transform.position, tr.position);
                ShowConnections(tr.gameObject);
            }

        }
    }

    public void SaveTree()
    {
        AssignRoot();
        AssignBlackboard();
        BuildTree(rootTask, behaviourTree.rootTask);
    }

    private void Update()
    {
        ShowConnections(rootTask);
    }



}
