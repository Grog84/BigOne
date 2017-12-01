using UnityEngine;
using AI.BT;
public class BTDMStringConverter
{
    public BehaviourTreeDM m_Tree;
    public string m_Code;

    TaskTool tTool = new TaskTool();

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
            taskCode += (int)task.m_Type;
        }

        string code = prefixCode + taskCode + "\n";
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

    public string WriteTree()
    {
        m_Code = "";
        ConvertToCode(m_Tree.rootTask, "0");
        Debug.Log(m_Code);
        return m_Code;
    }

    public Task CodeToTask(string code)
    {
        string lastLetter = code.Substring(code.Length - 1);
        if (lastLetter == "S")
        {
            Sequence sequenceTask = new Sequence();
            sequenceTask.m_BehaviourTree = m_Tree;
            sequenceTask.m_Type = TaskType.SEQUENCER;
            return sequenceTask;
        }
        else if (lastLetter == "Q")
        {
            Selector selectorTask = new Selector();
            selectorTask.m_BehaviourTree = m_Tree;
            selectorTask.m_Type = TaskType.SELECTOR;
            return selectorTask;
        }
        else
        {
            char[] delimiterChars = { 'T' };
            string[] codeSplit = code.Split(delimiterChars);
            string taskType = codeSplit[codeSplit.Length];
            tTool.GetTask();
        }
        return null;
    }

    public void BuildTreeFromCode()
    {
        char[] delimiterChars = { '\n' };
        string[] codes = m_Code.Split(delimiterChars);

        Task rootTask;


        foreach (var code in codes)
        {

        }
    }
    
}
