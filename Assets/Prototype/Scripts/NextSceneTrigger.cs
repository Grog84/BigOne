using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum Requirements
{
    ONE,
    BOTH
};

public class NextSceneTrigger : MonoBehaviour {

    public bool withInteraction = false;
    public bool goToNextScene = true;
    public int sceneIndex = 0;
    public Requirements requirements;
    private bool canChangeScene = false;
    private Icons canvasIcon;
   [HideInInspector] public int playerCount = 0; 

    private void Awake()
    {
        canvasIcon = GameObject.FindObjectOfType<Icons>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount++;

            if (requirements == Requirements.ONE)
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
            else if (requirements == Requirements.BOTH && playerCount == 2)
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

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerCount--;
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
