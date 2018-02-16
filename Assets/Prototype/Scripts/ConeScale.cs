using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class ConeScale : MonoBehaviour {

    public GameObject m_Cone;

    [Range(1f, 30f)]
    public float xScale = 4.0f;
    [Range(1f, 30f)]
    public float yScale = 4.0f;
    [Range(1f, 30f)]
    public float zScale = 4.0f;

    float oldXScale, oldYScale, oldZScale;

    private void Start()
    {
        oldXScale = xScale;
        oldYScale = yScale;
        oldZScale = zScale;

        m_Cone.transform.localScale = new Vector3(xScale, yScale, zScale);
        m_Cone.GetComponent<Cone>().UpdateRaycastParams();
    }

    private void Update()
    {
        if (oldXScale != xScale || oldYScale != yScale || oldZScale != zScale)
        {
            oldXScale = xScale;
            oldYScale = yScale;
            oldZScale = zScale;

            m_Cone.transform.localScale = new Vector3(xScale, yScale, zScale);
            m_Cone.GetComponent<Cone>().UpdateRaycastParams();

        }
    }

    // Commented in order to avoid errors in the console
    //private void OnValidate()
    //{
    //    m_Cone.transform.localScale= new Vector3(xScale, yScale, zScale);
    //    m_Cone.GetComponent<Cone>().UpdateRaycastParams();
    //}
}
