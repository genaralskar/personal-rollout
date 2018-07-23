using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpControl : MonoBehaviour 
{
	public AddPowerUp attackSpeed;
	public AddPowerUp damage;

	public float attackSpeedCoolDown;
	public float damageCoolDown;

	public Image coolDownImage;

	public void TriggerAttackSpeedUp()
	{
		StartCoroutine(PowerUpTimer(attackSpeedCoolDown, attackSpeed));
	}

	public void TriggerDamageUp()
	{
		StartCoroutine(PowerUpTimer(damageCoolDown, damage));
	}

	IEnumerator PowerUpTimer(float _coolDown, AddPowerUp _powerUp)
	{
		float currentCD = _coolDown;
		_powerUp.ApplyPowerUp();

		while(currentCD > 0)
		{
			yield return new WaitForSeconds(1f);
			currentCD--;
		}

		_powerUp.ResetStat();
	}
}
