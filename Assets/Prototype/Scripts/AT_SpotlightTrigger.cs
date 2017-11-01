using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AT_SpotlightTrigger : MonoBehaviour
{
    public Spotlightstats myStats;
    public bool lightSwitch;

    private Light m_light;
    private SphereCollider m_collider;

    private void Awake()
    {
        m_collider = GetComponent<SphereCollider>();
        m_light = GetComponent<Light>();
    }

    private void Start()
    {
        m_collider.radius = myStats.LightRange;
        m_light.range = myStats.LightRange;
        m_light.color = myStats.LightColor;
    }

    private void Update()
    {
    #if UNITY_EDITOR
        m_light.range = myStats.LightRange;
        m_collider.radius = myStats.LightRange;
        m_light.color = myStats.LightColor;
        
        if (lightSwitch)
        {
            this.GetComponent<Light>().intensity = myStats.intensity;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            this.GetComponent<Light>().intensity = 0;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    #endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            LightTestScript.TriggerLightEnter(this.gameObject);
          //  this.GetComponent<Light>().shadows = LightShadows.Soft;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            LightTestScript.TriggerLightExit(this.gameObject);
            //this.GetComponent<Light>().shadows = LightShadows.Soft;
        }
    }
}