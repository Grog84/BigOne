using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolCameraScroll : MonoBehaviour {

    public float scrollSpeed;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W))
            transform.position = new Vector3(transform.position.x,
                transform.position.y + scrollSpeed * Time.deltaTime, transform.position.z);

        if (Input.GetKey(KeyCode.A))
            transform.position = new Vector3(transform.position.x - scrollSpeed * Time.deltaTime,
                transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.S))
            transform.position = new Vector3(transform.position.x,
                transform.position.y - scrollSpeed * Time.deltaTime, transform.position.z);

        if (Input.GetKey(KeyCode.D))
            transform.position = new Vector3(transform.position.x + scrollSpeed * Time.deltaTime,
                transform.position.y, transform.position.z);
    }
}
