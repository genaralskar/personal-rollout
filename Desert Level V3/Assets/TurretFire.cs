using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class TurretFire : MonoBehaviour
{

	public ParticleSystem projectile;
	public float fireRate = 2;
	public GameEvent fireSound;
	
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
			fireSound.Raise();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		StopAllCoroutines();
	}
}
