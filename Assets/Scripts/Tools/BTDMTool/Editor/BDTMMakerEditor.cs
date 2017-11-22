using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BTDMMaker))]
public class BDTMMakerEditor : Editor
{
    BTDMMaker m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (BTDMMaker)target;
        DrawDefaultInspector();
        DrawCreateTaskButtons();

    }

    public void DrawCreateTaskButtons()
    {
        if (GUILayout.Button("Save Behaviour Tree"))
        {
            EditorApplication.Beep();
            if (EditorUtility.DisplayDialog("Save Behaviour Tree", "Are you sure you really want to save the current Behaviour tree?", "Yes", "No"))
            {
                m_Target.SaveTree();
                EditorUtility.SetDirty(m_Target.behaviourTree);
            }
        }
    }

}