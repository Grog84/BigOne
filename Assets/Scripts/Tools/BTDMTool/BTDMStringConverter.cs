using UnityEngine;
using System.Collections.Generic;
using AI.BT;

public class BTDMStringConverter
{
    public BehaviourTreeDM m_Tree;
    public string m_Code;

    //TaskTool tTool = new TaskTool();
    char[] delimiterChars = { 'S', 'Q', 'T' };

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
                string childPrefix = taskToCode.Substring(0, taskToCode.Length - 2) + i.ToString();
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
        if (lastLetter == "Q")
        {
            Sequence sequenceTask = new Sequence();
            sequenceTask.m_BehaviourTree = m_Tree;
            sequenceTask.m_Type = TaskType.SEQUENCER;
            return sequenceTask;
        }
        else if (lastLetter == "S")
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
            int taskType;
            System.Int32.TryParse(codeSplit[codeSplit.Length-1], out taskType);
            Task task = GetTask((TaskType)taskType);
            task.m_BehaviourTree = m_Tree;
            return task;
        }
    }

    public void BuildTreeFromCode()
    {
        char[] newlineChar = { '\n' };
        string[] codes = m_Code.Split(newlineChar);
        List<string> codesList = new List<string>(codes);

        Task rootTaskBase = CodeToTask(codes[0]);
        
        if (rootTaskBase.m_Type == TaskType.SELECTOR)
        {
            var rootTask = (Selector)rootTaskBase;
            rootTask.children = new List<Task>();
            BuildTreeFromCode(rootTask, codes[0], codesList);
            m_Tree.rootTask = rootTask;
        }
        else
        {
            var rootTask = (Sequence)rootTaskBase;
            rootTask.children = new List<Task>();
            BuildTreeFromCode(rootTask, codes[0], codesList);
            m_Tree.rootTask = rootTask;
        }
        //codesList.Remove(codes[0]);
        
    }

    // Make it with the 3 possible kind of task polymorphism
    public void BuildTreeFromCode(Selector task, string code, List<string> remainingCodes)
    {
        string parentPrefix = code.Split(delimiterChars)[0];
        int parentNestedLevel = parentPrefix.Length;

        for (int i = 0; i < remainingCodes.Count; i++)// (var cd in remainingCodes)
        {
            string prefix = remainingCodes[i].Split(delimiterChars)[0];
            int nestedLevel = prefix.Length;
            if (nestedLevel - parentNestedLevel == 1)
            {
                if (parentPrefix == prefix.Substring(0, prefix.Length-1))
                {
                    Task thisTaskBase = CodeToTask(remainingCodes[i]);
                    if (thisTaskBase.m_Type == TaskType.SELECTOR)
                    {
                        var thisTask = (Selector)thisTaskBase;
                        thisTask.children = new List<Task>();
                        BuildTreeFromCode(thisTask, remainingCodes[i], remainingCodes);
                        task.children.Add(thisTask);
                    }
                    else if (thisTaskBase.m_Type == TaskType.SEQUENCER)
                    {
                        var thisTask = (Sequence)thisTaskBase;
                        thisTask.children = new List<Task>();
                        BuildTreeFromCode(thisTask, remainingCodes[i], remainingCodes);
                        task.children.Add(thisTask);
                    }
                    else { task.children.Add(thisTaskBase); }
                    //remainingCodes.Remove(cd);
                }
            }
        }

        
    }

    public void BuildTreeFromCode(Sequence task, string code, List<string> remainingCodes)
    {
        string parentPrefix = code.Split(delimiterChars)[0];
        int parentNestedLevel = parentPrefix.Length;

        for (int i = 0; i < remainingCodes.Count; i++)
        {
            string prefix = remainingCodes[i].Split(delimiterChars)[0];
            int nestedLevel = prefix.Length;
            if (nestedLevel - parentNestedLevel == 1)
            {
                if (parentPrefix == prefix.Substring(0, prefix.Length - 1))
                {
                    Task thisTaskBase = CodeToTask(remainingCodes[i]);
                    if (thisTaskBase.m_Type == TaskType.SELECTOR)
                    {
                        var thisTask = (Selector)thisTaskBase;
                        thisTask.children = new List<Task>();
                        task.children.Add(thisTask);
                        BuildTreeFromCode(thisTask, remainingCodes[i], remainingCodes);
                    }
                    else if (thisTaskBase.m_Type == TaskType.SEQUENCER)
                    {
                        var thisTask = (Sequence)thisTaskBase;
                        thisTask.children = new List<Task>();
                        task.children.Add(thisTask);
                        BuildTreeFromCode(thisTask, remainingCodes[i], remainingCodes);
                    }
                    else { task.children.Add(thisTaskBase); }
                    //remainingCodes.Remove(cd);
                }
            }
        }

    }

    public Task GetTask(TaskType taskType)
    {
        Task thisTask;
        thisTask = InstantiateTask(taskType);
        thisTask.m_Type = taskType;
        return thisTask;
    }

    public Task InstantiateTask(TaskType taskType)
    {
        switch (taskType)
        {
            case TaskType.IS_LAST_NODE_REACHED:
                return new ConditionLastNodeReached();
            case TaskType.PATROL:
                return new ActionPatrol();
            case TaskType.GUARD_ALARMED:
                return new ActionAlarmed();
            case TaskType.GUARD_CHAR_CHASE:
                return new ActionChase();
            case TaskType.GUARD_CHECK_NAVPOINT:
                return new ActionCheckNavPoint();
            case TaskType.GUARD_STOP:
                return new ActionHoldPosition();
            case TaskType.GUARD_RANDOM_PATROL:
                return new ActionRandomPatrol();
            case TaskType.GUARD_REACH_LAST_PERCIEVED_POSITION:
                return new ActionReachLastPosition();
            case TaskType.GUARD_WAIT_NAVPOINT:
                return new ActionWaitNavPoint();
            case TaskType.GUARD_START_WAITING:
                return new ActionStartWaiting();
            case TaskType.GUARD_SWITCH_NAVPOINT:
                return new ActionSwitchNavPoint();
            case TaskType.GUARD_DEFEAT_PLAYER:
                return new ActionDefeatPlayer();
            case TaskType.GUARD_IS_ALARMED:
                return new ConditionAlarmed();
            case TaskType.GUARD_IS_CURIOUS:
                return new ConditionCurious();
            case TaskType.GUARD_IS_OTHER_ALARMED:
                return new ConditionIsOtherAlarmed();
            case TaskType.GUARD_IS_WAITING:
                return new ConditionIsWaiting();
            case TaskType.GUARD_IS_LAST_PERCIEVED_POSITION_REACHED:
                return new ConditionLastHeardSeenPosition();
            case TaskType.GUARD_IS_PLAYER_REACHED:
                return new ConditionPlayerReached();
            case TaskType.GUARD_IS_CHAR_VISIBLE:
                return new ConditionPlayerVisible();
            case TaskType.QUEST_NPC_GIVE_REWARD:
                return new ActionGiveReward();
            case TaskType.QUEST_NPC_IDLE:
                return new ActionIdle();
            case TaskType.QUEST_NPC_QUEST_NOT_COMPLETED:
                return new ActionQuestNotCompleted();
            case TaskType.QUEST_NPC_REQUEST:
                return new ActionRequest();
            case TaskType.QUEST_NPC_WATCH_PLAYER:
                return new ActionWatchPlayer();
            case TaskType.QUEST_NPC_THANKS:
                return new ActionThanks();
            case TaskType.QUEST_NPC_HAS_PLAYER_INTERACTED:
                return new ConditionPlayerInteracted();
            case TaskType.QUEST_NPC_HAS_SAW_PLAYER:
                return new ConditionPlayerSaw();
            case TaskType.QUEST_NPC_IS_QUEST_AVAILABLE:
                return new ConditionQuestAvailable();
            case TaskType.QUEST_NPC_IS_QUEST_COMPLETED:
                return new ConditionQuestCompleted();
            case TaskType.QUEST_NPC_IS_QUEST_TURNED_IN:
                return new ConditionQuestTurnedIn();
            case TaskType.PEDESTRIAN_DEFEAT_PLAYER:
                return new ActionPedestrianDefeatPlayer();
            case TaskType.PEDESTRIAN_PICK_NEW_DESTINATION:
                return new ActionPedestrianPickNewDestinationt();
            case TaskType.PEDESTRIAN_IS_PLAYER_CLIMBING:
                return new ConditionIsPlayerClimbing();
            case TaskType.PEDESTRIAN_IS_PLAYER_IN_RANGE:
                return new ConditionPedestrianPlayerInRange();
            case TaskType.PEDESTRIAN_IS_PLAYER_VISIBLE:
                return new ConditionPedestrianPlayerVisible();
            case TaskType.GUARD_SHOOT_PLAYER:
                return new ActionShootPlayer();
            case TaskType.GUARD_IS_DISTRACTED:
                return new ConditionDistracted();
            case TaskType.GUARD_STAY:
                return new ActionStay();
            default:
                return null;
        }
    }
}
