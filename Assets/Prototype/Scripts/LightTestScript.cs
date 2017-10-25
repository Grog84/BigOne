using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTestScript : MonoBehaviour {
    private Light thisLight;
    private Transform thisTransform;

    public Transform player;

    public Light worldLight;
    public Transform worldLightTransform;

    public float Distance;
    private bool onAnFaretto;

    [Range(0.0f, 10.0f)]
    public float range;
    // Update is called once per frame
    private void Start()
    {
        thisLight = this.GetComponent<Light>();
        thisTransform = this.GetComponent<Transform>();
        Debug.Log(this.gameObject.name + "Ha coordinate: x" + thisTransform.position.x + "y: " + thisTransform.position.y + "z: " + thisTransform.position.z);
    }

    void Update()
    {
        Distance = Vector3.Distance(player.position, thisTransform.transform.position);
        if (Distance <= range)
        {
            worldLight.type = thisLight.type;
            worldLightTransform.transform.position = thisTransform.transform.position;
            worldLightTransform.position += Vector3.up;
            onAnFaretto = true;
        }
        else if (Distance > range)
            onAnFaretto = false;

            if (onAnFaretto == false)
        {
            worldLight.type = LightType.Directional;
            worldLightTransform.position = new Vector3(0.12f, 20.77f, 3.49f);
        }
    }
}
 #region LightFollowPalyer
      /* public Light test;
    public Transform playerTransform;
	// Use this for initialization
	void Start () {
        test = GetComponent<Light>();
	}

        //values that will be set in the Inspector
    public Transform Target;
    public float RotationSpeed;




    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;
 void roba()
    {

       
    GetComponent<Light>().intensity = 1;
            //find the vector pointing from our position to the target
            _direction = (Target.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            _lookRotation = Quaternion.LookRotation(_direction);

            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

    }*/
    #endregion

