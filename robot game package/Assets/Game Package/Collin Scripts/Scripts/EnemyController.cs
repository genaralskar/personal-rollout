using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class EnemyController : MonoBehaviour
	{

		public float timeBetweenShots;
		public SpawnSOProjectile projectileSpawn;
		
		// Use this for initialization
		void Start ()
		{
			StartCoroutine(Fire());
		}

		private IEnumerator Fire()
		{
			while (true)
			{
				projectileSpawn.Spawn();	
				yield return new WaitForSeconds(timeBetweenShots);
			}
		}
	}
}

