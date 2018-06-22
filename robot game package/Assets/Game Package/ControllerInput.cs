using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{

	public FloatVariable xInput;
	public FloatVariable yInput;
	
	// Update is called once per frame
	void Update ()
	{
		xInput.FloatValue = Input.GetAxis("Horizontal");
		yInput.FloatValue = Input.GetAxis("Vertical");
	}
}
