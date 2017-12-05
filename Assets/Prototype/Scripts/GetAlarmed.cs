using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class GetAlarmed : MonoBehaviour
{
    

    private void OnTriggerStay(Collider other)
    {
        Vector3 dir = (other.transform.position - transform.position).normalized;
        RaycastHit hit;

       if (Physics.Raycast(transform.position, dir, out hit))
       {
            if(hit.transform.tag == "Enemy" && hit.transform.GetComponent<Guard>().GetState == GuardState.ALARMED)
            {
                transform.parent.GetComponent<Guard>().SetOtherAlarmed();
                transform.parent.GetComponent<Guard>().playerLastPercieved = hit.transform.GetComponent<Guard>().playerLastPercieved; 
            }
       }
      
    }

}
