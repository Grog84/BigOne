using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorTool : MonoBehaviour {

    public GameObject selector;
    public GameObject sequencer;
    public GameObject task;

    public void CreateSelector()
    {
        var thistask = Instantiate(selector, transform);
        task.transform.position += Vector3.down;    
    }

    public void CreateSequencer()
    {
        var thistask = Instantiate(sequencer, transform);
        task.transform.position += Vector3.down;
    }

    public void CreateTask()
    {
        var thistask = Instantiate(task, transform);
        task.transform.position += Vector3.down;
    }
}
