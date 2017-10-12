using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour {

    public float secondsStaying;
    public Transform directionPointer;

    [HideInInspector] public Vector3 facingDirection;

    private void Awake()
    {
        facingDirection = (directionPointer.position - transform.position).normalized;
    }
    
}
