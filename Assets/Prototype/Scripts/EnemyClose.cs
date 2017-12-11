using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : MonoBehaviour
{
    [HideInInspector] public GameObject enemyPointer;

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
            var thisPointer = Instantiate(enemyPointer, transform.parent);
            pointers.Add(thisPointer);
            thisPointer.GetComponent<EnemyRadar>().target = other.gameObject;
            thisPointer.GetComponent<EnemyRadar>().enemyClose = this.transform;
        }
    }
    
}
