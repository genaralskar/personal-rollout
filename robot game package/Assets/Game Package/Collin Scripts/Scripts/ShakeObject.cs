using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class ShakeObject : MonoBehaviour
{

	private bool isShaking = false;

	private float xRotShake;
	private float yRotShake;
	private float zRotShake;

	private float xTransShake;
	private float yTransShake;
	private float zTransShake;

	public GameObject objectToShake;
	private Vector3 objectStartPosLocal;
	private Vector3 objectStartRotLocal;

	public float shakeModifier = 10;
	public float frequency = 1;

	[Range(0, 1)] private float trauma = 0;
	private float shakeAmount;

	public void Start()
	{
		if (objectToShake == null)
		{
			objectToShake = gameObject;
		}
		
		objectStartPosLocal = objectToShake.transform.localPosition;
		objectStartRotLocal = objectToShake.transform.rotation.eulerAngles;
	}
	
	public void AddShake(float amount)
	{
		print("shake called!");
		trauma += amount;
		trauma = Mathf.Clamp(trauma, 0, 1);
		if (!isShaking)
		{
			StartCoroutine(ShakeIt());
		}
	}

	private IEnumerator ShakeIt()
	{
		print("start shaking!");
		isShaking = true;
		float timer = 0;
		while (trauma > 0)
		{
			timer += Time.deltaTime;
			shakeAmount = trauma * trauma;

			xRotShake = (Mathf.PerlinNoise(Time.time + .1f * frequency, timer * frequency) - .5f) * 2;
			yRotShake = (Mathf.PerlinNoise(Time.time + .2f * frequency, timer - .1f * frequency) - .5f) * 2;
			zRotShake = (Mathf.PerlinNoise(Time.time + .3f * frequency, timer + .1f * frequency) - .5f) * 2;
			
			Vector3 shakeRot = new Vector3(xRotShake, yRotShake, zRotShake);
			shakeRot *= shakeAmount * shakeModifier;

			xTransShake = (Mathf.PerlinNoise(Time.time + .4f * frequency, timer - .2f * frequency) - .5f) * 2;
			yTransShake = (Mathf.PerlinNoise(Time.time + .5f * frequency, timer + .3f * frequency) - .5f) * 2;
			zTransShake = (Mathf.PerlinNoise(Time.time + .6f * frequency, timer - .3f * frequency) - .5f) * 2;
			Vector3 transRot = new Vector3(xTransShake, yTransShake, zTransShake);
			transRot *= shakeAmount * shakeModifier;
			Shake(shakeRot, transRot);
			
			trauma -= Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		
		isShaking = false;
	}

	void Shake(Vector3 shakeRotVector, Vector3 shakeTransVector)
	{
	//	print("shaking by " + shakeRotVector);
		Vector3 newRotVector = shakeRotVector + objectStartRotLocal;
		//objectToShake.transform.localRotation = Quaternion.Euler(newRotVector);

		Vector3 newTransVector = shakeTransVector + objectStartPosLocal;
		objectToShake.transform.localPosition = newTransVector;

	}
}
