using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class Hitbox : MonoBehaviour
	{
		public FloatConstant damage;
	
		private void OnTriggerEnter(Collider other)
		{
		//	print("Triggered");
			Hurtbox otherManager = other.gameObject.GetComponent<Hurtbox>();
			otherManager.healthManager.AddHealth(-damage.FloatValue);
		//	print("damaged object");
		}
	}
}

