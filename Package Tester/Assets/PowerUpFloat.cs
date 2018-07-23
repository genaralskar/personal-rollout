using UnityEngine;

[CreateAssetMenu(fileName = "PowerUpFloat")]
public class PowerUpFloat : ScriptableObject 
{
	public float powerUpAmount;

	public float PowerUpAmount
	{
		get { return powerUpAmount; }
		set { powerUpAmount = value; }
	}
}
