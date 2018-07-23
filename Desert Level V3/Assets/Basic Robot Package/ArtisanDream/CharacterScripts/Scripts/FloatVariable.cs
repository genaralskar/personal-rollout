using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable")]
public class FloatVariable : InputBase, IInput 
{
	private float floatValue;

	private void OnEnable()
	{
		FloatValue = 0;
	}

	public float FloatValue
	{
		get { return floatValue; }
		set { floatValue = value; }
	}

	public override float SetFloat()
	{
	//	Debug.Log(floatValue);
		return floatValue;
	}
}
