using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AT_NearestSpotlight : MonoBehaviour {
 static GameObject Player = GameObject.FindGameObjectWithTag("Player");
    public static Vector3 NearestSpotlight(List<Light> LightConflict)
    {
    
        float[] Distance = new float[LightConflict.Count];
        int index=-1;
        float min = 10000000000000;
        for (int i = 0; i < Distance.Length; i++)
        {
            Distance[i] = Vector3.Distance(Player.transform.position, LightConflict[i].gameObject.transform.position);
            
        }
        for (int i = 0; i < Distance.Length; i++)
        {
            if (Distance.Min() == Distance[i])
            {

                return LightConflict[i].transform.position;
            }
        }
        return Vector3.zero;
     

        
    }
}
