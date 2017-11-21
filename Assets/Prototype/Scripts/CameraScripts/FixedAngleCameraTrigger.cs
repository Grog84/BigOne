using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FixedAngleCameraTrigger : MonoBehaviour {

    [Tooltip("La telecamera con priorità maggiora sarà quella visualizzata a schermo," +
        "il valore di default della telecamera principale è 15, " +
        "quello della telecamera in prima persona è 100, se si vuole avere un trigger di telecamera " +
        "FirsPerson all'interno di una zona a telecamera fissa si deve mantenere la priorità della telecamera fissa minore di 100")]

    public int priorityAmmount = 0;
    private CinemachineVirtualCamera fixedAngleCamera;
    private CameraScript mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.GetComponent<CameraScript>();
        fixedAngleCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        fixedAngleCamera.m_Priority = priorityAmmount;
    //        fixedAngleCamera.m_LookAt = other.transform;
    //        mainCamera.activatedByTrigger = true;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        fixedAngleCamera.m_Priority = -10;
    //        mainCamera.activatedByTrigger = false;
    //        fixedAngleCamera.m_LookAt = null;
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                fixedAngleCamera.m_Priority = priorityAmmount;
                mainCamera.activatedByTrigger = true;
                fixedAngleCamera.m_LookAt = other.transform;
                //mainCamera.boyInTrigger = true;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                fixedAngleCamera.m_Priority = priorityAmmount;
                mainCamera.activatedByTrigger = true;
                fixedAngleCamera.m_LookAt = other.transform;
                //mainCamera.motherInTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.name == "Boy" && (int)GMController.instance.isCharacterPlaying == 0)
            {
                fixedAngleCamera.m_Priority = 0;
                mainCamera.activatedByTrigger = false;
                mainCamera.boyInTrigger = false;
                fixedAngleCamera.m_LookAt = null;
            }
            else if (other.name == "Mother" && (int)GMController.instance.isCharacterPlaying == 1)
            {
                fixedAngleCamera.m_Priority = 0;
                mainCamera.activatedByTrigger = false;
                mainCamera.motherInTrigger = false;
                fixedAngleCamera.m_LookAt = null;
            }
        }
    }



}
