using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapTool))]
public class MapToolProtoEditor : Editor
{
    MapTool m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (MapTool)target;
        DrawDefaultInspector();
        DrawSaveLoadButtons();

    }

    void DrawSaveLoadButtons()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("Save"))
            {
                EditorApplication.Beep();
                if (EditorUtility.DisplayDialog("Save Configuration", "Are you sure you really want to save the current configuration?", "Yes", "No"))
                {
                    m_Target.SaveConfig();
                    EditorUtility.SetDirty(m_Target);
                }

            }

            if (GUILayout.Button("Load"))
            {
                EditorApplication.Beep();
                if (EditorUtility.DisplayDialog("Load Configuration", "Load the current configuration?", "Yes", "No"))
                {
                    m_Target.LoadConfig();
                }
            }
        }
        GUILayout.EndHorizontal();
    }

}
