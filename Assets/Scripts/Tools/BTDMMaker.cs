using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI.BT;
using AI;
using System.Linq;

public class BTDMMaker : MonoBehaviour {

    public BehaviourTreeDM behaviourTree;
    public GameObject rootTask;

    public enum AgentType { GUARD }
    public AgentType thisAgentType = AgentType.GUARD;

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
                    task.m_BehaviourTree = behaviourTree;
                }
                else if (tr.gameObject.tag == "ToolSelector")
                {
                    task = new Selector();
                    task.m_BehaviourTree = behaviourTree;
                }
                else
                {
                    Debug.Log("There's gonna be a real task");
                }


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
            behaviourTree.AssignRootTask(sequenceTask);

        }
        else if (rootTask.tag == "ToolSelector")
        {
            Selector selectorTask = new Selector();
            selectorTask.m_BehaviourTree = behaviourTree;
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
                behaviourTree.m_Blackboard = new GuardBlackboard();
                break;
            default:
                break;
        }
    }

    public void PrintTree()
    {
        behaviourTree.PrintTree(0, behaviourTree.rootTask);
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

    void Start () {

        AssignRoot();
        AssignBlackboard();
        BuildTree(rootTask, behaviourTree.rootTask);
        Debug.Log("Done Talking");
    }

    private void Update()
    {
        ShowConnections(rootTask);
    }



}
