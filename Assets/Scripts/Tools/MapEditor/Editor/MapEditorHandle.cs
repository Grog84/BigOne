using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class MapEditorHandle : Editor
{

    public static Vector3 CurrentHandlePosition = Vector3.zero;
    public static bool IsMouseInValidArea = true;

    static Vector3 m_OldHandlePosition = Vector3.zero;

    static MapEditorHandle()
    {
        //The OnSceneGUI delegate is called every time the SceneView is redrawn and allows you
        //to draw GUI elements into the SceneView to create in editor functionality
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;
    }

    void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {
        if (IsInCorrectLevel() == false)
        {
            return;
        }

        
        bool isLevelEditorEnabled = EditorPrefs.GetBool("IsLevelEditorEnabled", true);

        if (isLevelEditorEnabled == false)
        {
            return;
        }

        UpdateHandlePosition(sceneView);
        UpdateRepaint();

        DrawCubeDrawPreview();
    }

    static bool IsInCorrectLevel()
    {
        return UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name != "Menu";
    }

    static void UpdateHandlePosition(SceneView sceneView)
    {
        if (Event.current == null)
        {
            return;
        }

        Vector2 mousePosition = new Vector2(Event.current.mousePosition.x, Event.current.mousePosition.y);

        Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity) &&
            Event.current.mousePosition.x > 110 &&
            Event.current.mousePosition.y < sceneView.position.height - 35)
        {
            IsMouseInValidArea = true;
            CurrentHandlePosition = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }
        else
        {
            IsMouseInValidArea = false;
        }
    }

    static void UpdateRepaint()
    {
        //If the cube handle position has changed, repaint the scene
        if (CurrentHandlePosition != m_OldHandlePosition)
        {
            SceneView.RepaintAll();
            m_OldHandlePosition = CurrentHandlePosition;
        }
    }

    static void DrawCubeDrawPreview()
    {
        //if (IsMouseInValidArea == false)
        //{
        //    return;
        //}

        Handles.color = new Color(EditorPrefs.GetFloat("CubeHandleColorR", 1f),
            EditorPrefs.GetFloat("CubeHandleColorG", 1f),
            EditorPrefs.GetFloat("CubeHandleColorB", 0f));
        
        DrawHandlesCube(CurrentHandlePosition);
    }

    static void DrawHandlesCube(Vector3 center)
    {
        GameObject selectedPrefab = MapEditor.m_Database.blocksList[MapEditor.SelectedBlock].prefabsList[MapEditor.SelectedPrefab].Prefab;
        Vector3 bounds = Vector3.zero;

        if(selectedPrefab)
        {
            // Resize Handle - commented in order to solve a blocking bug
            //if (selectedPrefab.GetComponent<MeshFilter>())
            //    bounds = selectedPrefab.GetComponent<MeshFilter>().sharedMesh.bounds.extents;
            //else
            //{
            //    Bounds combinedBounds = new Bounds();
            //    pb_Object[] pbObjs = selectedPrefab.GetComponentsInChildren<pb_Object>();

            //    foreach (var pbObj in pbObjs)
            //    {
            //        pbObj.GetComponent<pb_Object>().Verify();
            //        combinedBounds.Encapsulate(pbObj.msh.bounds);
            //        //Debug.Log(pbObj.msh.bounds.extents);
            //    }

            //    bounds = combinedBounds.extents;
            //    //Debug.Log(bounds);
            //}

            bounds = new Vector3(0.5f, 0.5f, 0.5f);
        }


        Vector3 p1 = center + Vector3.right * bounds.x + Vector3.forward * bounds.z;
        Vector3 p2 = center + Vector3.right * bounds.x - Vector3.forward * bounds.z;
        Vector3 p3 = center - Vector3.right * bounds.x - Vector3.forward * bounds.z;
        Vector3 p4 = center - Vector3.right * bounds.x + Vector3.forward * bounds.z;

        Vector3 p5 = center + Vector3.up * bounds.y * 2f + Vector3.right * bounds.x + Vector3.forward * bounds.z;
        Vector3 p6 = center + Vector3.up * bounds.y * 2f + Vector3.right * bounds.x - Vector3.forward * bounds.z;
        Vector3 p7 = center + Vector3.up * bounds.y * 2f - Vector3.right * bounds.x - Vector3.forward * bounds.z;
        Vector3 p8 = center + Vector3.up * bounds.y * 2f - Vector3.right * bounds.x + Vector3.forward * bounds.z;

        //You can use Handles to draw 3d objects into the SceneView. If defined properly the
        //user can even interact with the handles. For example Unitys move tool is implemented using Handles
        //However here we simply draw a cube that the 3D position the mouse is pointing to
        Handles.DrawLine(p1, p2);
        Handles.DrawLine(p2, p3);
        Handles.DrawLine(p3, p4);
        Handles.DrawLine(p4, p1);

        Handles.DrawLine(p5, p6);
        Handles.DrawLine(p6, p7);
        Handles.DrawLine(p7, p8);
        Handles.DrawLine(p8, p5);

        Handles.DrawLine(p1, p5);
        Handles.DrawLine(p2, p6);
        Handles.DrawLine(p3, p7);
        Handles.DrawLine(p4, p8);
    }
}
