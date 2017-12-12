using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapEditorResetPrefs))]
public class MapEditorResetPrefsEditor : Editor {

	MapEditorResetPrefs m_Target;

	public override void OnInspectorGUI()
	{
		m_Target = (MapEditorResetPrefs)target;
		MapEditorResetPrefsButton ();

	}

	void MapEditorResetPrefsButton()
	{
		
		if (GUILayout.Button("RESET"))
		{
			EditorApplication.Beep();
			if (EditorUtility.DisplayDialog("Reset Prefs", "Are you sure you really want to reset the current Editor prefs?", "Yes", "No"))
			{
				m_Target.ResetPrefs();

			}

		}


	}


}
