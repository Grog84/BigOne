using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : MonoBehaviour
{
     public GameObject enemyPointer;

    public List<GameObject> pointers;

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
            if(pointers.Count == 1)
            {
                GMController.instance.SetBkgMusicState(22);
            }
        }
    }
    
}
