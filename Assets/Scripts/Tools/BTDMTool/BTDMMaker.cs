using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using AI.BT;
using AI;
using System.Linq;

public class BTDMMaker : MonoBehaviour {

    public BehaviourTreeDM behaviourTree;
    public GameObject rootTask;
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
                behaviourTree.m_Blackboard = new GuardBlackboard();
                thisBlackboard = behaviourTree.m_Blackboard;
                break;
            default:
                break;
        }
    }

    public void PrintTree()
    {
        var converter = new BTDMStringConverter();
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
        behaviourTree = ScriptableObject.CreateInstance<BehaviourTreeDM>();
#if UNITY_EDITOR
        AssetDatabase.CreateAsset(behaviourTree, "Assets/ScriptableObjects/AI/NewBDTM.asset");
        AssetDatabase.SaveAssets();
#endif
        AssignRoot();
        AssignBlackboard();
        BuildTree(rootTask, behaviourTree.rootTask);

        var converter = new BTDMStringConverter();
        converter.m_Tree = behaviourTree;
        behaviourTree.codeStructure = converter.WriteTree();

        EditorUtility.SetDirty(behaviourTree);
    }

    private void Update()
    {
        ShowConnections(rootTask);
    }



}
