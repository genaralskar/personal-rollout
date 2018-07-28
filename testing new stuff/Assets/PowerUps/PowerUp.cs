using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp")]
public class PowerUp : ScriptableObject 
{
	public FloatVariable powerUp;
	public float coolDown;
	public float powerUpAmount;

	public void ApplyPowerUp()
	{
		powerUp.FloatValue = powerUpAmount;
	}

	public void ResetStat()
	{
		powerUp.FloatValue = 1f;
	}
}
