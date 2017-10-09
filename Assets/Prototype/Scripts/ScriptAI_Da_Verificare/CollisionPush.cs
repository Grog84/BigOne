using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPush : MonoBehaviour {

    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //Crea Null reference perchè non sempre ha un parent
    private void OnCollisionEnter(Collision collision)
    {
       // if (player.GetComponent<move>().startPush)
      //  {
            if (collision.gameObject.layer == LayerMask.NameToLayer("PushRail"))
            {
                transform.parent.transform.GetComponent<_CharacterController>().isPushLimit = true;
            }
       // }
    }

    private void OnCollisionExit(Collision collision)
    {
      //  if (player.GetComponent<move>().startPush)
      //  {
            if (collision.gameObject.layer == LayerMask.NameToLayer("PushRail"))
            {
                transform.parent.transform.GetComponent<_CharacterController>().isPushLimit = false;
            }
       // }
    }

}
