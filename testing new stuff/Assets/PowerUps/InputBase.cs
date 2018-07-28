using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputBase : ScriptableObject
{
	public abstract float SetFloat ();
}

public interface IInput
{
	float SetFloat();
}