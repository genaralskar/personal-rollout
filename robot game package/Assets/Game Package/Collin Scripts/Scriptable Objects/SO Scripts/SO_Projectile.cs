using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	[CreateAssetMenu(menuName = "genaralskar/Projectile")]
	public class SO_Projectile : ScriptableObject
	{
		public GameObject ProjectilePrefab
		{
			get { return pooledObject.prefab; }
		}

		[SerializeField]
		private Pool pooledObject;
		public Pool PooledObject
		{
			get { return pooledObject; }
		}
	
		[SerializeField]
		private float projectileLifetime = 5;
		public float ProjectileLifetime
		{
			get { return projectileLifetime; }
		}
	
		[SerializeField]
		private float cooldown = 1;
		public float Cooldown
		{
			get { return cooldown; }
		}

		[SerializeField]
		private bool parent = false;
		public bool Parent
		{
			get { return parent; }
		}
	}
}

