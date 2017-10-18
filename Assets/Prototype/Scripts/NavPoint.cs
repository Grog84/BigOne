using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour {

    public float secondsStaying = 6f;
    public bool isPassageOnly = false;
    public Transform directionPointer;

    [HideInInspector] public Vector3 facingDirection;

    private void Awake()
    {
        facingDirection = (directionPointer.position - transform.position).normalized;
    }

    private void OnValidate()
    {
        if (isPassageOnly)
        {
            secondsStaying = 0f;
        }
        else
        {
            secondsStaying = Mathf.Max(6.0f, secondsStaying);
        }
    }

}
