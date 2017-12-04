//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEditor;
//using UnityEngine.SceneManagement;

//[InitializeOnLoad]
//public class PatrolEditorNavpointPlacement : Editor
//{
//    static bool hasClickedOnce = false;

//    static PatrolEditorNavpointPlacement()
//    {
//        SceneView.onSceneGUIDelegate -= OnSceneGUI;
//        SceneView.onSceneGUIDelegate += OnSceneGUI;

//    }

//    void OnDestroy()
//    {
//        SceneView.onSceneGUIDelegate -= OnSceneGUI;
//    }

//    static void OnSceneGUI(SceneView sceneView)
//    {
//        if(PatrolEditorHandle.isActive)
//            HandleLevelEditorPlacement();
        
//    }

//    static void HandleLevelEditorPlacement()
//    {

//        ////By creating a new ControlID here we can grab the mouse input to the SceneView and prevent Unitys default mouse handling from happening
//        ////FocusType.Passive means this control cannot receive keyboard input since we are only interested in mouse input
//        int controlId = GUIUtility.GetControlID(FocusType.Passive);

//        ////If the left mouse is being clicked and no modifier buttons are being held
//        if (Event.current.type == EventType.mouseDown &&
//            Event.current.button == 0 &&
//            Event.current.alt == false &&
//            Event.current.shift == false &&
//            Event.current.control == false)
//        {
//            Debug.Log(PatrolEditorHandle.IsMouseInValidArea);
//            if (PatrolEditorHandle.IsMouseInValidArea == true)
//            {
//                if (!hasClickedOnce)
//                {
//                    Debug.Log("First Click");
//                    AddNavPoint(PatrolEditorHandle.CurrentHandlePosition);
//                }

//                PatrolEditorHandle.isActive = false;
//            }
//        }

//        ////If we press escape we want to automatically deselect our own painting or erasing tools
//        if (Event.current.type == EventType.keyDown &&
//            Event.current.keyCode == KeyCode.Escape)
//        {
//            PatrolEditorHandle.isActive = false;
//        }

//        HandleUtility.AddDefaultControl(controlId);
//    }

//    public static void AddNavPoint(Vector3 position)
//    {

//        GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
//        newObj.transform.position = position;

//        //Make sure a proper Undo/Redo step is created. This is a special type for newly created objects
//        Undo.RegisterCreatedObjectUndo(newObj, "Add Navpoint");

//        //UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
//        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
//    }
//}
