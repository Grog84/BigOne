using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(StateTool))]
public class StateToolEditor : Editor
{
    static StateTool m_Target;
    public override void OnInspectorGUI()
    {
        m_Target = (StateTool)target;
        DrawDefaultInspector();
        DrawButtons();
    }

    void DrawButtons()
    {
        GUILayout.BeginHorizontal();
        {
            if (GUILayout.Button("NORMAL"))
            {
                m_Target.m_Guard.SetPerceptionToValue(0f);
                m_Target.m_Guard.GetNormal();
            }

            if (GUILayout.Button("CURIOUS"))
            {
                m_Target.m_Guard.SetBlackboardValue("LastPercievedPosition", m_Target.playerTransform.position);
                m_Target.m_Guard.SetPerceptionToValue(50f);
                //m_Target.m_Guard.GetCurious();

            }

            if (GUILayout.Button("ALARMED"))
            {
                m_Target.m_Guard.SetBlackboardValue("LastPercievedPosition", m_Target.playerTransform.position);
                m_Target.m_Guard.GetAlarmed();
            }

        }
        GUILayout.EndHorizontal();
    }

    
}
