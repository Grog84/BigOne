using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(NavPointCreator))]
public class NavPointCreatorEditor : Editor
{
    static NavPointCreator m_Target;
    static bool hasClickedOnce = false;
    static GameObject activeObj;
    static Vector2 oldMousePos = Vector2.zero;

    static bool showPath = false;
    static float sphereMovementTotalTime = 10f;
    static float sphereMovementTime = 0f;

    static void OnSceneGUI(SceneView sceneView)
    {
        if (showPath)
            ShowPath();

        if (PatrolEditorHandle.isActive)
            HandleLevelEditorPlacement();

        SceneView.RepaintAll();
    }

    static void HandleLevelEditorPlacement()
    {
        ////By creating a new ControlID here we can grab the mouse input to the SceneView and prevent Unitys default mouse handling from happening
        ////FocusType.Passive means this control cannot receive keyboard input since we are only interested in mouse input
        int controlId = GUIUtility.GetControlID(FocusType.Passive);
        if (hasClickedOnce)
        {    
            Vector2 newMousePos = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);
            Vector2 displacement = oldMousePos - newMousePos;
            oldMousePos = newMousePos;
            activeObj.transform.Rotate(Vector3.up * displacement.x, Space.World);
        }

        ////If the left mouse is being clicked and no modifier buttons are being held
        if (Event.current.type == EventType.mouseDown &&
            Event.current.button == 0 &&
            Event.current.alt == false &&
            Event.current.shift == false &&
            Event.current.control == false)
        {

            if (PatrolEditorHandle.IsMouseInValidArea == true)
            {
                if (!hasClickedOnce)
                {
                    hasClickedOnce = true;
                    AddNavPoint(PatrolEditorHandle.CurrentHandlePosition);
                    oldMousePos = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);
                }
                else if (hasClickedOnce)
                {
                    hasClickedOnce = false;
                    SceneView.onSceneGUIDelegate -= OnSceneGUI;
                    m_Target.AddNavpoint(activeObj.GetComponent<NavPoint>());
                    PatrolEditorHandle.isActive = false;
                    UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
                }
                
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

    public static void AddNavPoint(Vector3 position)
    {

        GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(m_Target.navPoint);
        newObj.transform.position = position + Vector3.up;
        activeObj = newObj;

        //Make sure a proper Undo/Redo step is created. This is a special type for newly created objects
        Undo.RegisterCreatedObjectUndo(newObj, "Add Navpoint");

        //UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
        UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
    }

    static void ShowPath()
    {
        sphereMovementTime = (float)EditorApplication.timeSinceStartup;
        sphereMovementTime %= sphereMovementTotalTime;
        Handles.color = m_Target.gizmoColor;

        // draw line between waypoints
        for (int i = 0; i < m_Target.m_Guard.wayPointList.Count; i++)
        {
            if (i == m_Target.m_Guard.wayPointList.Count - 1)
            {
                Handles.DrawLine(m_Target.m_Guard.wayPointList[i].transform.position, m_Target.m_Guard.wayPointList[0].transform.position);
                Vector3 positionDiff = m_Target.m_Guard.wayPointList[0].transform.position - m_Target.m_Guard.wayPointList[i].transform.position;

                Handles.DrawWireCube(m_Target.m_Guard.wayPointList[i].transform.position + positionDiff * sphereMovementTime / sphereMovementTotalTime,
                    new Vector3(0.1f, 0.1f, 0.1f));
            }
            else
            {
                Handles.DrawLine(m_Target.m_Guard.wayPointList[i].transform.position, m_Target.m_Guard.wayPointList[i + 1].transform.position);
                Vector3 positionDiff = m_Target.m_Guard.wayPointList[i + 1].transform.position - m_Target.m_Guard.wayPointList[i].transform.position;
                Handles.DrawWireCube(m_Target.m_Guard.wayPointList[i].transform.position + positionDiff * sphereMovementTime / sphereMovementTotalTime,
                    new Vector3(0.1f, 0.1f, 0.1f));
            }
        }
    }

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
                SceneView.onSceneGUIDelegate -= OnSceneGUI;
                SceneView.onSceneGUIDelegate += OnSceneGUI;
                PatrolEditorHandle.isActive = true;

            }

            if (GUILayout.Button("SHOW"))
            {
                showPath = !showPath;
                if (showPath)
                {
                    SceneView.onSceneGUIDelegate -= OnSceneGUI;
                    SceneView.onSceneGUIDelegate += OnSceneGUI;
                }
                else
                {
                    SceneView.onSceneGUIDelegate -= OnSceneGUI;
                }

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
