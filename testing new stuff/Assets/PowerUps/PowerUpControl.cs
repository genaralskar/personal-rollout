using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpControl : MonoBehaviour 
{
	public PowerUp powerUp;

	private void OnTriggerEnter(Collider other)
	{
		StartCoroutine(PowerUpTimer(powerUp));
	}

	IEnumerator PowerUpTimer(PowerUp _powerUp)
	{
		float currentCD = _powerUp.coolDown;
		_powerUp.ApplyPowerUp();
		print("powered up stat: " + _powerUp.powerUp.FloatValue);

		while(currentCD > 0)
		{
			print(currentCD);
			yield return new WaitForSeconds(1f);
			currentCD--;
		}

		_powerUp.ResetStat();
		print("original stat: " + _powerUp.powerUp.FloatValue);
	}
}
