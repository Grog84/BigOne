using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextSceneTrigger : MonoBehaviour {

    public bool withInteraction = false;
    public bool goToNextScene = true;
    public int sceneIndex = 0;

    private bool canChangeScene = false;
    private Icons canvasIcon;


    private void Awake()
    {
        canvasIcon = GameObject.FindObjectOfType<Icons>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!withInteraction && goToNextScene)
                GMController.instance.MoveToNextScene();
            else if (!withInteraction && !goToNextScene)
            {
                GMController.instance.MoveToScene(sceneIndex);
            }
            else
            {
                canChangeScene = true;
                canvasIcon.transform.Find("ChangeScene").gameObject.SetActive(true);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canChangeScene = false;
            canvasIcon.transform.Find("ChangeScene").gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (canChangeScene && Input.GetButtonDown("Interact"))
        {
            if (goToNextScene)
                GMController.instance.MoveToNextScene();
            else
                GMController.instance.MoveToScene(sceneIndex);
        }
    }
}
