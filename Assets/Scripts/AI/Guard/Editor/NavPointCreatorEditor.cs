using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(NavPointCreator))]
public class NavPointCreatorEditor : Editor
{
    NavPointCreator m_Target;  

    public override void OnInspectorGUI()
    {
        m_Target = (NavPointCreator)target;
        DrawDefaultInspector();
        DrawAddResetButtons();

    }

    void DrawAddResetButtons()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("ADD"))
            {
                PatrolEditorHandle.isActive = true;

            }

            if (GUILayout.Button("RESET"))
            {
                EditorApplication.Beep();
                if (EditorUtility.DisplayDialog("Reset Navpoints", "Reset all the guard navpoints?", "Yes", "No"))
                {
                    m_Target.m_Guard.wayPointList.Clear();
                }
            }
        }
        GUILayout.EndHorizontal();
    }

}
