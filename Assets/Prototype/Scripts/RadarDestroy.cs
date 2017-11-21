using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarDestroy : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == transform.parent.GetComponent<EnemyRadar>().target)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
