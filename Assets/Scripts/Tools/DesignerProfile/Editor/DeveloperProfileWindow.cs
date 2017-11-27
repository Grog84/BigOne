using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DeveloperProfileWindow : EditorWindow
{
    static DeveloperProfileEnum thisProfile;

    [MenuItem("Window/Developer Profile")]
    static void Init()
    {
        thisProfile = (DeveloperProfileEnum)EditorPrefs.GetInt("MapConfig");
        EditorWindow window = GetWindow(typeof(DeveloperProfileWindow));
        window.Show();
    }

    void OnGUI()
    {
        thisProfile = (DeveloperProfileEnum)EditorGUILayout.EnumPopup("Developer Profile: ", thisProfile);

        if (GUILayout.Button("Load Profile", GUILayout.Height(30)))
        {
            EditorPrefs.SetInt("MapConfig", (int)thisProfile);
        }

    }
}
