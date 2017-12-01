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
            if (EditorUtility.DisplayDialog("Save Behaviour Tree", "Are you sure you really want to save the current Behaviour tree?" +
                "\n NOTE: PLAY MODE MUST BE ACTIVE", "Yes", "No"))
            {
                m_Target.SaveTree();

                AssetDatabase.Refresh();
                EditorUtility.SetDirty(m_Target);
                EditorUtility.SetDirty(m_Target.behaviourTree);
                AssetDatabase.SaveAssets();

                //EditorUtility.SetDirty(m_Target.behaviourTree);
            }
        }

        if (GUILayout.Button("Print Tree"))
        {

            m_Target.PrintTree();
           
        }
    }

}