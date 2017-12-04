using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarScale : MonoBehaviour {

    public GameObject m_Cone;
    public bool locked;

    [Range(1f, 50f)]
    public float xzScale = 22f;
    [Range(1f, 50f)]
    public float yScale = 1f;
  
    private void OnValidate()
    {
        m_Cone.transform.localScale= new Vector3(xzScale, yScale, xzScale);
        if (locked)
        {
            m_Cone.transform.localPosition = new Vector3(0, yScale, 0);
        }
    }
}
