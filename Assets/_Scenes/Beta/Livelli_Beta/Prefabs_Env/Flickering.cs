using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {

	private Light[] lights;
	private int roll;

	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 0.1f;

	bool lightsOff = false;

	void Start () 
	{
		lights = GetComponentsInChildren<Light> ();
		roll = Random.Range(1, 10);

		if (roll > 0)   ///TODO: ALWAYS TRUE
		{
			StartCoroutine (Flicker());
		}
	}


	void Update()
	{
//		if (lightsOff == true) 
//		{
//			foreach(Light light in lights)
//				light.enabled = false;
//		} 
//		else 
//		{
//			foreach (Light light in lights)
//				light.enabled = true;
//		}

	}


	IEnumerator Flicker()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
			foreach(Light light in lights)
				light.enabled = false;
			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
			foreach (Light light in lights)
				light.enabled = true;

			yield return null;
		}
	}
}
