using System;
using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class TurretFire : MonoBehaviour
{

	public ParticleSystem projectile;
	public float fireRate = 2;
	public GameEvent fireSound;
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
			yield return new WaitForSeconds(fireRate);
			if(PlayerBlockedCheck())
			{
				projectile.Play();
				fireSound.Raise();
			}
		}
	}

	private bool PlayerBlockedCheck()
	{
		Debug.DrawRay(raycastTransform.position, raycastTransform.forward * 100, Color.green);
		if(Physics.Raycast(raycastTransform.position, raycastTransform.forward, obstacleLayer))
		{
			print("false");
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
