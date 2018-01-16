using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framerate : MonoBehaviour {

    Text m_text;
    int frameRate;

    void Start()
    {
        m_text = GetComponent<Text>();
         
    }

	// Update is called once per frame
	void Update () {

        frameRate = (int)(1f / Time.deltaTime);
        m_text.text = frameRate.ToString();

    }
}
