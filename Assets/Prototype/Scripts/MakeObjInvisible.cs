﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjInvisible : MonoBehaviour {

    private List<MeshRenderer> meshRenderers;
    public bool atStart = true;

    // Use this for initialization
    void Start () {

        if(atStart)
        {
            MakeInvisible();
        }

	}

    public void MakeInvisible()
    {
        meshRenderers = new List<MeshRenderer>();
        if (GetComponent<MeshRenderer>())
            GetComponent<MeshRenderer>().enabled = false;


        if (gameObject.GetComponentsInChildren<MeshRenderer>().Length != 0)
        {
            foreach (var meshRend in GetComponentsInChildren<MeshRenderer>())
            {
                meshRend.enabled = false;
            }

        }
    }

}
