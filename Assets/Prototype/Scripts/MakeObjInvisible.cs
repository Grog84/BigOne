﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjInvisible : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<MeshRenderer>().enabled = false;

	}
	
}
