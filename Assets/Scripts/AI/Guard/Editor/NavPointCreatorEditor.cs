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

    static void HandleLevelEditorPlacement()
    {
        if (ToolMenuEditor.SelectedTool == 1)
        {
            return;
        }

        ////This method is very similar to the one in E08. Only the AddBlock function is different

        ////By creating a new ControlID here we can grab the mouse input to the SceneView and prevent Unitys default mouse handling from happening
        ////FocusType.Passive means this control cannot receive keyboard input since we are only interested in mouse input
        int controlId = GUIUtility.GetControlID(FocusType.Passive);

        ////If the left mouse is being clicked and no modifier buttons are being held
        if (Event.current.type == EventType.mouseDown &&
            Event.current.button == 0 &&
            Event.current.alt == false &&
            Event.current.shift == false &&
            Event.current.control == false)
        {
            if (PatrolEditorHandle.IsMouseInValidArea == true)
            {
                PatrolEditorHandle.isActive = false;
            }
        }

        ////If we press escape we want to automatically deselect our own painting or erasing tools
        if (Event.current.type == EventType.keyDown &&
            Event.current.keyCode == KeyCode.Escape)
        {
            PatrolEditorHandle.isActive = false;
        }

        HandleUtility.AddDefaultControl(controlId);
    }
}
