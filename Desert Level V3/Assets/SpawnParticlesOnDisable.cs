using System.Collections;
using System.Collections.Generic;
using genaralskar;
using UnityEngine;

public class SpawnParticlesOnDisable : MonoBehaviour
{
	public GameObject explosionParticle;
	
	private void OnDisable()
	{
		print("Disabled!");
		Instantiate(explosionParticle, transform.position, transform.rotation);
	}
}
