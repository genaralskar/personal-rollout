using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{

	public ParticleSystem projectile;
	public float fireRate = 2;
	
	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(Fire());
	}

	private IEnumerator Fire()
	{
		while (true)
		{
			yield return new WaitForSeconds(fireRate);
			projectile.Play();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		StopAllCoroutines();
	}
}
