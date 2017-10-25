using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SpotlightTrigger : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LightTestScript.TriggerLightEnter(this.gameObject);
 
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            LightTestScript.TriggerLightExit(this.gameObject);
        }
    }
}