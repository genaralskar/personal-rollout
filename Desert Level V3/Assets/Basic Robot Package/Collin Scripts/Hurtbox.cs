using System.Collections;
using System.Collections.Generic;
using genaralskar;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

namespace genaralskar
{
	public class Hurtbox : MonoBehaviour
	{
	
		public HealthManager healthManager;
        [Range(0,100)]
        public float armor;
		public float invincibleTime = .1f;

		private void OnParticleCollision(GameObject other)
		{
			print("Hurtbox Triggered");
			Weapon otherWeapon = other.GetComponent<ParticleCallBack>().weapon;
            float damage = otherWeapon.damage - armor;

            damage = Mathf.Clamp(damage, 1, 100); //prevent damage from going negative, and always does some damage
			Debug.Log(damage);
            healthManager.AddHealth((int)-damage);
			if(otherWeapon.screenShakeOnHitEvent != null)
				otherWeapon.screenShakeOnHitEvent.Raise();
			if(otherWeapon.hitSoundEvent != null)
				otherWeapon.hitSoundEvent.Raise();
		}
		
	}
}

