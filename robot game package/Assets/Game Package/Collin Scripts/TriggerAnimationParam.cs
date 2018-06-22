using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimationParam : MonoBehaviour
{

	public Animator anims;
	
	public void Trigger(string param)
	{
		anims.SetTrigger(param);
	}

	public void Bool(string param, bool state)
	{
		anims.SetBool(param, state);
	}

	public void Float(string param, float value)
	{
		anims.SetFloat(param, value);
	}
}
