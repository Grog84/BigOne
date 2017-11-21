using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
using StateMachine;
using System.IO;

public class ToolManager : MonoBehaviour {

    private List<_Action> allActions;

	// Use this for initialization
	void Start () {

        allActions = new List<_Action>();

        DirectoryInfo dir = new DirectoryInfo("Assets/Prototype/ScriptableObjects/Actions/Enemies");
        FileInfo[] info = dir.GetFiles("*.asset");

        foreach (FileInfo f in info)
        {
            //allActions.Add(AssetDatabase.FindAssets(f.FullName));
        }

        //allActions = AssetDatabase.FindAssets("t:ScriptObj", ["Assets/MyAwesomeProps"]);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
