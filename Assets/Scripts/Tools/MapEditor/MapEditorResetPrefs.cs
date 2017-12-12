using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapEditorResetPrefs : MonoBehaviour {

	public void ResetPrefs()
	{
		EditorPrefs.SetBool("IsLevelEditorEnabled", false);
		EditorPrefs.SetInt("SelectedBlock", 0);
		EditorPrefs.SetInt("SelectedPrefab", 0);
		EditorPrefs.SetInt("SelectedMaterial", 0);
	}
}
