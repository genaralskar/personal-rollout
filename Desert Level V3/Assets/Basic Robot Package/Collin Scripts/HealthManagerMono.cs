using System.Collections;
using System.Collections.Generic;
using genaralskar;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class HealthManagerMono : MonoBehaviour
{
	
	public HealthManager manager;
	public GameObject deathParticles;
	public Vector3 deathParticleSpawnOffset;
	public GameEvent deathEvent;
	
	// Use this for initialization
	private void OnEnable()
	{
		manager.SetHealth((float)1);
	}

	private void Start()
	{
		manager.healthAtZero += HealthAtZeroHandler;
	}

	public void HealthAtZeroHandler()
	{
		print("Health at zero!");
		
		if(deathParticles != null)
			Instantiate(deathParticles, transform.position + deathParticleSpawnOffset, transform.rotation);

		if (deathEvent != null)
		{
			deathEvent.Raise();
		}
		
		gameObject.SetActive(false);
	}
}
