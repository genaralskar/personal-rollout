using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp")]
public class AddPowerUp : ScriptableObject 
{
	public PowerUpFloat powerUp;
	public MovePatternUngroundedMovement _defaultStat;

	public float tempStat;

	public void ApplyPowerUp()
	{
		tempStat = _defaultStat.speed;
		_defaultStat.speed *= powerUp.powerUpAmount;
	}

	public void ResetStat()
	{
		_defaultStat.speed = tempStat;
	}
}
