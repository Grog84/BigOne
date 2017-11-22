using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeTool : MonoBehaviour {

    public BTDMMaker bTDMMaker;

    public void CreateSelector()
    {
        var thistask = Instantiate(bTDMMaker.selector, transform);
        thistask.transform.localPosition += new Vector3(0f, -5f, 0f);
        //thistask.transform.localScale = new Vector3(1f,1f,0f);
        thistask.GetComponent<CompositeTool>().bTDMMaker = bTDMMaker;
    }

    public void CreateSequencer()
    {
        var thistask = Instantiate(bTDMMaker.sequencer, transform);
        thistask.transform.localPosition += new Vector3(0f, -5f, 0f);
        //thistask.transform.localScale = new Vector3(2f, 1f, 0f);
        thistask.GetComponent<CompositeTool>().bTDMMaker = bTDMMaker;
    }

    public void CreateTask()
    {
        var thistask = Instantiate(bTDMMaker.task, transform);
        thistask.transform.localPosition += new Vector3(0f, -5f, 0f);
        //thistask.transform.localScale = new Vector3(1f, 1f, 0f);
    }
}
