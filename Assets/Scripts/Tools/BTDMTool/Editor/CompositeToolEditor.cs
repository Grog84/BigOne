using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CompositeTool))]
public class CompositeToolEditor : Editor
{
    CompositeTool m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (CompositeTool)target;
        DrawDefaultInspector();
        DrawCreateTaskButtons();

    }

    public void DrawCreateTaskButtons()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Add Selector"))
            {
                m_Target.CreateSelector();              
            }

            if (GUILayout.Button("Add Sequencer"))
            {
                m_Target.CreateSequencer();
            }

            if (GUILayout.Button("Add Task"))
            {
                m_Target.CreateTask();
            }

        }
        GUILayout.EndHorizontal();
    }

}
