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
    float fullXScale, fullYScale, fullZScale;

    private void Start()
    {
        fullXScale = xScale;
        fullYScale = yScale;
        fullZScale = zScale;

        oldXScale = xScale;
        oldYScale = yScale;
        oldZScale = zScale;

        m_Cone.transform.localScale = new Vector3(xScale, yScale, zScale);
        m_Cone.GetComponent<Cone>().UpdateRaycastParams();

        StartCoroutine(ResizeCO());
    }


    IEnumerator ResizeCO()
    {
        for (; ;)
        {
            if (oldXScale != xScale || oldYScale != yScale || oldZScale != zScale)
            {
                oldXScale = xScale;
                oldYScale = yScale;
                oldZScale = zScale;

                m_Cone.transform.localScale = new Vector3(xScale, yScale, zScale);
                m_Cone.GetComponent<Cone>().UpdateRaycastParams();

            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void Shrink()
    {
        xScale = 0.01f;
        yScale = 0.01f;
        zScale = 0.01f;
    }

    public void Grow()
    {
        xScale = fullXScale;
        yScale = fullYScale;
        zScale = fullZScale;
    }

    private void OnValidate()
    {
        // Commented in order to avoid errors in the console
        //m_Cone.transform.localScale = new Vector3(xScale, yScale, zScale);
        //m_Cone.GetComponent<Cone>().UpdateRaycastParams();
        
        fullXScale = xScale;
        fullYScale = yScale;
        fullZScale = zScale;
    }
}
