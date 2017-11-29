using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class MapEditor : Editor
{
    public static MapEditorDatabase m_Database;

    static GUIStyle style = new GUIStyle();
    static Vector2 scrollPosition = Vector2.zero;
    static int itemCount;
    static bool[] blocksStatus;
    static int offset;
    static bool isStart = true;

    static int blockTagSpacing = 15;
    static int buttonSize = 128;
    static int buttonSpacing = 35;

    //static Transform m_LevelParent;
    //static Transform LevelParent
    //{
    //    get
    //    {
    //        if (m_LevelParent == null)
    //        {
    //            GameObject go = GameObject.Find("Level");

    //            if (go != null)
    //            {
    //                m_LevelParent = go.transform;
    //            }
    //        }

    //        return m_LevelParent;
    //    }
    //}

    public static int SelectedBlock
    {
        get
        {
            return EditorPrefs.GetInt("SelectedBlock", 0);
        }
        set
        {
            EditorPrefs.SetInt("SelectedBlock", value);
        }
    }

    //Get or Set which Prefab is selected in our custom menu
    public static int SelectedPrefab
    {
        get
        {
            return EditorPrefs.GetInt("SelectedPrefab", 0);
        }
        set
        {
            EditorPrefs.SetInt("SelectedPrefab", value);
        }
    }

    static MapEditor()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        SceneView.onSceneGUIDelegate += OnSceneGUI;

        m_Database = AssetDatabase.LoadAssetAtPath<MapEditorDatabase>("Assets/Scripts/Tools/MapEditor/MapEditorDatabase.asset");
        style.normal.textColor = Color.black;

    }

    void OnDestroy()
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
    }

    static void OnSceneGUI(SceneView sceneView)
    {

        if (isStart)
        {
            isStart = false;
            itemCount = 0;
            foreach (var block in m_Database.blocksList)
            {
                itemCount += block.prefabsList.Count;
            }

            blocksStatus = new bool[m_Database.blocksList.Count];
            for (int i = 0; i < blocksStatus.Length; i++)
            {
                blocksStatus[i] = true;
            }
        }

        if (IsInCorrectLevel() == false)
        {
            return;
        }

        if (m_Database == null)
        {
            return;
        }

        if (ToolMenuEditor.SelectedTool == 1)
        {
            DrawCustomButtons(sceneView);
            HandleLevelEditorPlacement();
        }
    }

    static void HandleLevelEditorPlacement()
    {
        if (ToolMenuEditor.SelectedTool == 0)
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
            if (MapEditorHandle.IsMouseInValidArea == true)
            {

                if (ToolMenuEditor.SelectedTool == 1)
                {
                    if (SelectedPrefab < m_Database.blocksList.Count)
                    {
                        AddGameObject(MapEditorHandle.CurrentHandlePosition, m_Database.blocksList[SelectedBlock].prefabsList[SelectedPrefab].Prefab);
                    }
                }

            }
        }

        ////If we press escape we want to automatically deselect our own painting or erasing tools
        if (Event.current.type == EventType.keyDown &&
            Event.current.keyCode == KeyCode.Escape)
        {
            ToolMenuEditor.SelectedTool = 0;
        }

        HandleUtility.AddDefaultControl(controlId);
    }

    //Draw a list of our custom blocks on the left side of the SceneView
    static void DrawCustomButtons(SceneView sceneView)
    {
        Handles.BeginGUI();

        GUI.Box(new Rect(0, 0, 110, sceneView.position.height - 35), GUIContent.none, EditorStyles.textArea);

        offset = 0;


        scrollPosition = GUI.BeginScrollView(new Rect(0, 0, 125, sceneView.position.height - 35), scrollPosition, new Rect(0, 0, 110, itemCount * buttonSize + 25));

        for (int i = 0; i < m_Database.blocksList.Count; ++i)
        {
            DrawCustomBlock(i, sceneView.position, offset);
            if (blocksStatus[i])
                offset += m_Database.blocksList[i].prefabsList.Count * buttonSize + blockTagSpacing;
            else
                offset += blockTagSpacing;
        }

        GUI.EndScrollView();

        Handles.EndGUI();
    }

    static void DrawCustomBlock(int index, Rect sceneView, int offset)
    {
        blocksStatus[index] = EditorGUI.Foldout(new Rect(0, offset, 125, blockTagSpacing), blocksStatus[index], m_Database.blocksList[index].Name);

        if (blocksStatus[index])
        {
            for (int i = 0; i < m_Database.blocksList[index].prefabsList.Count; i++)
            {
                DrawCustomButton(index, i, sceneView, offset);
            }
        }

    }

    static void DrawCustomButton(int blockIndex, int index, Rect sceneViewRect, int offset)
    {
        bool isActive = false;

        if (ToolMenuEditor.SelectedTool == 1 && index == SelectedPrefab && blockIndex == SelectedBlock)
        {
            isActive = true;
        }

        //By passing a Prefab or GameObject into AssetPreview.GetAssetPreview you get a texture that shows this object
        Texture2D previewImage = AssetPreview.GetAssetPreview(m_Database.blocksList[blockIndex].prefabsList[index].Prefab);
        GUIContent buttonContent = new GUIContent(previewImage);


        GUI.Label(new Rect(5, offset + index * buttonSize + 15, 100, 20), m_Database.blocksList[blockIndex].prefabsList[index].Name, style);
        bool isToggleDown = GUI.Toggle(new Rect(5, offset + index * buttonSize + 35, 100, 100), isActive, buttonContent, GUI.skin.button);

        //If this button is clicked but it wasn't clicked before (ie. if the user has just pressed the button)
        if (isToggleDown == true && isActive == false)
        {
            SelectedBlock = blockIndex;
            SelectedPrefab = index;
            ToolMenuEditor.SelectedTool = 1;
        }
    }

    public static void AddGameObject(Vector3 position, GameObject prefab)
    {
        if (prefab == null)
        {
            return;
        }

        GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
        //newObj.transform.parent = LevelParent;
        newObj.transform.position = position;

        //Make sure a proper Undo/Redo step is created. This is a special type for newly created objects
        Undo.RegisterCreatedObjectUndo(newObj, "Add " + prefab.name);

        UnityEditor.SceneManagement.EditorSceneManager.MarkAllScenesDirty();
    }

    //I will use this type of function in many different classes. Basically this is useful to 
    //be able to draw different types of the editor only when you are in the correct scene so we
    //can have an easy to follow progression of the editor while hoping between the different scenes
    static bool IsInCorrectLevel()
    {
        //Debug.Log(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name != "Menu");
        return UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene().name != "Menu";
        //return true;
    }

}
