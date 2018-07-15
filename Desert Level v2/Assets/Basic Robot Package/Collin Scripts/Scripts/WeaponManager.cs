using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

	public ParticleSystem particle;
	[Range(0,100)]public int damage;
	public float cooldown = 0.5f;
	private bool canFire = true;

	public void Fire()
	{
		if (canFire)
		{
			particle.Play();
			StopAllCoroutines();
			StartCoroutine(Cooldown());
		}
	}
	
	
	

	private IEnumerator Cooldown()
	{
		canFire = false;
		float timer = 0;
		while (timer < cooldown)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		canFire = true;
	}
	
}
