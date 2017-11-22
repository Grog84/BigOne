using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : MonoBehaviour
{
    [HideInInspector] public GameObject enemyPointer;
    [HideInInspector] public float pos;

    public List<GameObject> pointers;
    public float arrowDistance;

    private void Awake()
    {
        pointers = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            pos -= arrowDistance;
            var thisPointer = Instantiate(enemyPointer, transform.parent);
            pointers.Add(thisPointer);
            thisPointer.GetComponent<EnemyRadar>().target = other.gameObject;
            thisPointer.GetComponent<EnemyRadar>().pos = pos;
            thisPointer.GetComponent<EnemyRadar>().enemyClose = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            pos += arrowDistance;
        }
    }
}
