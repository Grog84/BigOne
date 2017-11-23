using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DesignerProfileWindow : EditorWindow
{
    [MenuItem("Window/Designer Profile")]
    static void OpenPreviewPlaybackWindow()
    {
        EditorWindow.GetWindow<DesignerProfileWindow>(false, "Playback");
    }

    public MapToolConfig mapToolConfig;


}
