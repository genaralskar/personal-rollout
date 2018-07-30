using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

[CreateAssetMenu(menuName = "genaralskar/Weapon")]
public class Weapon : ScriptableObject
{

	public GameObject projectile;
	public FloatConstant projectileDamage;
	
	public int damage
	{
		get 
		{
			return (damageMultiplier != null && damageMultiplier.FloatValue > 0) ? //if multiplier isn't zero or null
				(int)(projectileDamage.FloatValue * damageMultiplier.FloatValue) : //return with mutlilier
				(int)projectileDamage.FloatValue; //else send just damage
		}
	}
	
	public FloatConstant cooldown;
	public FloatVariable damageMultiplier;
	public FloatVariable cooldownMultiplier;
	public GameEvent fireSoundEvent;
	public GameEvent hitSoundEvent;
	public GameEvent screenShakeOnHitEvent;

	public void Fire(Transform spawnLoc)
	{
		GameObject part = Instantiate(projectile, spawnLoc.position, spawnLoc.rotation);
		ParticleCallBack pcb = part.AddComponent<ParticleCallBack>();
		pcb.weapon = this;
		fireSoundEvent.Raise();
	}

}
