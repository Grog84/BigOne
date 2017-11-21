﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

[CreateAssetMenu(menuName = "Tools/MapToolConfig")]
public class MapToolConfig : ScriptableObject
{
    [HideInInspector] public SceneSetup[] sceneSetup;
}
