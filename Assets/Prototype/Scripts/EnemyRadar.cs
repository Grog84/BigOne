using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using DG.Tweening;

public class EnemyRadar : MonoBehaviour
{

    public float pos;
    public GameObject target;
    public Vector3 dir;
    public Vector3 oldDir;
    public Coroutine rotateCoroutine;

    public Vector3 newTarget;

    void Awake ()
    {
       transform.position = transform.parent.position + Vector3.up/2 + new Vector3(0,pos,0);

	}

    IEnumerator FollowTarget(Vector3 target)
    {
        float rotatingSpeed = 10f;
        while ((transform.forward - target).sqrMagnitude > 0.01f)
        {
            float step = rotatingSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(transform.forward, target, step, 0.0f); ;
            transform.rotation = Quaternion.LookRotation(newDir);
            yield return null;
        }
    
    }

    void UpdateDir()
    {
        dir = target.transform.position - transform.position;
        dir.y = 0;
        dir = dir.normalized;
    }

    private void Update()
    {
        newTarget = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        // Debug.Log((oldDir - dir).sqrMagnitude);
        // UpdateDir();
        /* if ((oldDir - dir).sqrMagnitude > 0.005f)
         {
             oldDir = dir;

             if(rotateCoroutine != null)
             {
                 StopCoroutine(rotateCoroutine);
             }

             rotateCoroutine = StartCoroutine(FollowTarget(oldDir));

         }*/

        transform.DOLookAt(newTarget, 0.1f);
    }
}
