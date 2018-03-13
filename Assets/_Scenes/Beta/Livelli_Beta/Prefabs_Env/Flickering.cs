using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickering : MonoBehaviour {

	public GameObject emitter;
	private Light[] lights;

	public bool isAlwaysFlickering = false;
	public float minFlickerSpeed = 0.1f;
	public float maxFlickerSpeed = 0.1f;
	public float flickerDuration = 3f;

	public int chance = 1000;
	private int roll;

	void Start () 
	{
		lights = GetComponentsInChildren<Light> ();

		if (isAlwaysFlickering)   
			StartCoroutine (Flicker());
	}


	void Update()
	{
		roll = Random.Range (0, chance);
		if (!isAlwaysFlickering && roll < 1) 
			StartCoroutine(FlickerTimed());
	}


	IEnumerator Flicker()
	{
		while(true)
		{
			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            if (emitter != null)
                emitter.SetActive(false);
            foreach (Light light in lights)
				light.enabled = false;
			
			int otherRoll = 0;
			otherRoll = Random.Range (0, 20);
			if (otherRoll < 1) 
			{
				yield return new WaitForSeconds(Random.Range(0f, 1f));
			}


			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            if (emitter != null)
			    emitter.SetActive(true);
			foreach (Light light in lights)
				light.enabled = true;

			otherRoll = Random.Range (0, 20);
			if (otherRoll < 1) 
			{
				yield return new WaitForSeconds(Random.Range(0f, 1f));
			}

			yield return null;
		}
	}

	IEnumerator FlickerTimed()
	{
		float startTime;
		startTime = Time.time;

		while(Time.time - startTime < flickerDuration)
		{
			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
			emitter.SetActive(false);
			foreach(Light light in lights)
				light.enabled = false;
			yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
			emitter.SetActive(true);
			foreach (Light light in lights)
				light.enabled = true;

			yield return null;
		}
	}
}
