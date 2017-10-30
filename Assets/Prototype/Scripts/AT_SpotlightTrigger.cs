using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SpotlightTrigger : MonoBehaviour
{
    public bool lightSwitch;
    private void Update()
    {
        if(lightSwitch)
        {
            this.GetComponent<Light>().intensity=1;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green; }
        else
        {
            this.GetComponent<Light>().intensity = 0;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red; }
    }
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