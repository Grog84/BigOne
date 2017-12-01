using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PatrolEditorNavpointPlacement : Editor
{
    static PatrolEditorNavpointPlacement()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;

    }

    void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if(PatrolEditorHandle.isActive)
            HandleLevelEditorPlacement();
        
    }


    static void HandleLevelEditorPlacement()
    {

        ////By creating a new ControlID here we can grab the mouse input to the SceneView and prevent Unitys default mouse handling from happening
        ////FocusType.Passive means this control cannot receive keyboard input since we are only interested in mouse input
        int controlId = GUIUtility.GetControlID(FocusType.Passive);
        Debug.Log(Event.current.type == EventType.mouseDown);

        ////If the left mouse is being clicked and no modifier buttons are being held
        if (Event.current.type == EventType.mouseDown &&
            Event.current.button == 0 &&
            Event.current.alt == false &&
            Event.current.shift == false &&
            Event.current.control == false)
        {
            Debug.Log(PatrolEditorHandle.IsMouseInValidArea);
            if (PatrolEditorHandle.IsMouseInValidArea == true)
            {
                Debug.Log("Click");
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
