using System.Collections;
using System.Collections.Generic;
using genaralskar;
using UnityEngine;

public class EnemyHealthManagerMono : HealthManagerMono
{

	[SerializeField] private Hurtbox[] hurtboxes;
	[SerializeField] private UIHealth healthUI;
	
	// Use this for initialization
	void Awake ()
	{	
		FloatConstant tempCurrentHealth = ScriptableObject.CreateInstance<FloatConstant>();
		tempCurrentHealth.FloatValue = manager.currentHealth.FloatValue;
		
		manager = ScriptableObject.CreateInstance<HealthManager>();
		manager.currentHealth = tempCurrentHealth;
		Debug.Log(manager.currentHealth.FloatValue);

		healthUI.healthManager = manager;
		
		manager.healthAtZero += HealthAtZeroHandler;
		manager.healthUpdate += HealthUpdateHandler;
		
		foreach (var hurtbox in hurtboxes)
		{
			hurtbox.healthManager = manager;
		}
	}

	private void HealthUpdateHandler(float currentHealth)
	{
		
	}

	private void HealthAtZeroHandler()
	{
		if(deathPartles != null)
			Instantiate(deathPartles, transform.position, transform.rotation);
		
		gameObject.SetActive(false);
	}

	
}
