using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

	public ParticleSystem particle;
	[Range(0,100)]public int damage;
	public float cooldown = 0.5f;
	private bool canFire = true;
	public GameEvent Event;

	public void Fire()
	{
		if (canFire)
		{
			canFire = false;
			particle.Play();
			Event.Raise();
			StopAllCoroutines();
			StartCoroutine(Cooldown());
		}
	}

	private IEnumerator Cooldown()
	{
		print("Cooldown Start");
		canFire = false;
		float timer = 0;
		while (timer < cooldown)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		canFire = true;
		print("Cooldown End");
	}
	
}
