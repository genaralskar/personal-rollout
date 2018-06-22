using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	[RequireComponent(typeof(Rigidbody))]
	public class BulletController : MonoBehaviour, IPooledObject
	{
		
		private Rigidbody rb;

		public float bulletSpeed = 20;
		
		// Use this for initialization
		private void Awake ()
		{
			rb = GetComponent<Rigidbody>();
		}

		public void OnObjectSpawned()
		{
		//	print("bullet OnObjectSpawned spawning!");
			rb.velocity = transform.forward * bulletSpeed;
		}
		
	}
}

