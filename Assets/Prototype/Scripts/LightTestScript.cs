using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTestScript : MonoBehaviour {
   /* public Light test;
    public Transform playerTransform;
	// Use this for initialization
	void Start () {
        test = GetComponent<Light>();
	}*/

    //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;
   

   

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Target.position, this.transform.position) <= 10f)
        {
            GetComponent<Light>().intensity = 1;
            //find the vector pointing from our position to the target
            _direction = (Target.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
        else
        {
            this.transform.eulerAngles = new Vector3(90, 0, 0);
            GetComponent<Light>().intensity = 0;
        }
    }
}
