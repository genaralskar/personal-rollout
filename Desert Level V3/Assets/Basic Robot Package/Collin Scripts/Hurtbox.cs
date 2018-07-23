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
		public GameEvent screenShake;
		public GameEvent hitSound;
		public float invincibleTime = .1f;

		private void OnParticleCollision(GameObject other)
		{
			print("Hurtbox Triggered");
			WeaponManager otherWeapon = other.GetComponent<WeaponManager>();
            float damage;

            if (otherWeapon.multiplier != null)
                damage = (otherWeapon.damage * otherWeapon.multiplier.FloatValue) - armor;
            else
                damage = otherWeapon.damage - armor;
			Debug.Log(otherWeapon.damage);
			Debug.Log(damage);
            damage = Mathf.Clamp(damage, 0, 100); //prevent damage from going negative
			Debug.Log(damage);
            healthManager.AddHealth((int)-damage);
			if(screenShake != null)
				screenShake.Raise();
			hitSound.Raise();
		}
		
	}
}

