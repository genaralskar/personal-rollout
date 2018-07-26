using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnable : MonoBehaviour
{

	public float delay = 2;

	private void OnEnable()
	{
		Destroy(gameObject, delay);
	}
}
