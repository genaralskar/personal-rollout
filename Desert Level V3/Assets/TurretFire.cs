using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class TurretFire : MonoBehaviour
{

	public Weapon weapon;
	public Transform spawnPoint;
	
	public LayerMask obstacleLayer;
	public LayerMask targetLayer;
	public Transform raycastTransform;

	private void Start()
	{
		if (raycastTransform == null)
		{
			raycastTransform = transform;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(Fire());
	}

	private IEnumerator Fire()
	{
		while (true)
		{
			if (weapon != null)
			{
				yield return new WaitForSeconds(weapon.cooldown.FloatValue);
			}
			else
			{
				yield return new WaitForSeconds(2f);
			}
			
			if(PlayerBlockedCheck())
			{
				weapon.Fire(spawnPoint);
//				projectile.Play();
//				fireSound.Raise();
			}
		}
	}

	private void Update()
	{
		Debug.DrawRay(raycastTransform.position, raycastTransform.forward * 100, Color.green);
	}

	private bool PlayerBlockedCheck()
	{
		RaycastHit hit;	
		if(Physics.Raycast(raycastTransform.position, raycastTransform.forward, out hit, obstacleLayer))
		{
			print("player blocked by: " + hit.collider.gameObject);
			return false;
		}
		print("true");
		return PlayerHitCheck();
	}

	private bool PlayerHitCheck()
	{
		RaycastHit hit;
		if(Physics.SphereCast(raycastTransform.position, .1f, raycastTransform.forward, out hit, Mathf.Infinity, targetLayer))
		{
			print("player hit");
			return true;
		}
		print("player not hit");
		return false;
	}

	private void OnTriggerExit(Collider other)
	{
		StopFiring();
	}

	public void StopFiring()
	{
		StopAllCoroutines();
	}
}
