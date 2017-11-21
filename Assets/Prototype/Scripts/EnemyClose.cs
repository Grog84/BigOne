using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClose : MonoBehaviour
{
    public GameObject enemyPointer;
    public float pos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            pos -= 0.2f;
            var thisPointer = Instantiate(enemyPointer, transform.parent);
            thisPointer.GetComponent<EnemyRadar>().target = other.gameObject;
            thisPointer.GetComponent<EnemyRadar>().pos = pos;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            pos += 0.2f;
        }
    }
}
