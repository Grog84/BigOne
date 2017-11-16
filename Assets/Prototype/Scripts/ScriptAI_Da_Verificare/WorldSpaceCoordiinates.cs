using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpaceCoordiinates : MonoBehaviour
{
	
	// Update is called once per frame
	void Update () {
        Debug.Log(this.transform.localToWorldMatrix.ToString());
	}
}
