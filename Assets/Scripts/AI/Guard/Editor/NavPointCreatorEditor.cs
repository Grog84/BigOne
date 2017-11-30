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
                Debug.Log("add");
                //m_Target.SaveConfig();
                //EditorUtility.SetDirty(m_Target.myConfigFile);

            }

            if (GUILayout.Button("RESET"))
            {
                EditorApplication.Beep();
                if (EditorUtility.DisplayDialog("Reset Navpoints", "Reset all the guard navpoints?", "Yes", "No"))
                {
                    Debug.Log("reset");
                    //m_Target.LoadConfig();
                }
            }
        }
        GUILayout.EndHorizontal();
    }
}
