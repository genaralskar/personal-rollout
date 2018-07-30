using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	public int damage
	{
		get 
		{
			return (weapon.damageMultiplier.FloatValue > 0 || weapon.damageMultiplier != null) ? //if multiplier isn't zero
			(int)(weapon.projectileDamage.FloatValue * weapon.damageMultiplier.FloatValue) : //return with mutlilier
			(int)weapon.projectileDamage.FloatValue; //else send just damage
		}
	}
	
	public Weapon weapon;
	private bool canFire = true;

	public void Fire()
	{
		if (canFire)
		{
			canFire = false;
			weapon.Fire(transform);
			StopAllCoroutines();
			StartCoroutine(Cooldown());
		}
	}

	private IEnumerator Cooldown()
	{
	//	print("Weapon Cooldown Start");
		canFire = false;
		float timer = 0;
		while (timer < weapon.cooldown.FloatValue)
		{
			timer += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}

		canFire = true;
	//	print("Weapon Cooldown End");
	}
	
}
