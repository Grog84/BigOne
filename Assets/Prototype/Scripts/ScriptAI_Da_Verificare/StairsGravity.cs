using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsGravity : MonoBehaviour {
    
    bool StairsCheck()
    {
        RaycastHit hitInfo;
        Ray ray = new Ray(this.transform.position, Vector3.down);
        Physics.Raycast(ray, out hitInfo, 0.20f);

        if ( hitInfo.collider.tag == "Stairs")
        {            
            return true;
        }
        else
        {
            return false;
        }
    }

}
