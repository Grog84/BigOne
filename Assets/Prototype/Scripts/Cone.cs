using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cone : MonoBehaviour {

    public ConeStats coneStats;
    public bool isDebug;

	void Start () {

        transform.localScale.Set(coneStats.scaleX, coneStats.scaleY, coneStats.scaleZ);
	}

    private void Update()
    {
        if (isDebug)
        {
            transform.localScale.Set(coneStats.scaleX, coneStats.scaleY, coneStats.scaleZ);
        }

    }

}
