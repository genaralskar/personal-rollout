using System.Collections;
using System.Collections.Generic;
using genaralskar;
using UnityEngine;

public class HealthManagerMono : MonoBehaviour
{
	
	public HealthManager manager;
	public ParticleSystem deathPartles;
	
	// Use this for initialization
	private void OnEnable()
	{
		manager.SetHealth((float)1);
	}
}
