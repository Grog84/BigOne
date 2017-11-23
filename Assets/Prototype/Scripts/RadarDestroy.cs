using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarDestroy : MonoBehaviour
{
    public Transform enemyClose;

    void Start()
    {
        enemyClose = transform.parent.GetComponent<EnemyRadar>().enemyClose;
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == transform.parent.GetComponent<EnemyRadar>().target)
        {
            enemyClose.GetComponent<EnemyClose>().pointers.Remove(transform.parent.gameObject);
            Destroy(transform.parent.gameObject);
        }
    }
}
