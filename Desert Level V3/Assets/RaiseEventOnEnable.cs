using System.Collections;
using System.Collections.Generic;
using RoboRyanTron.Unite2017.Events;
using UnityEngine;

public class RaiseEventOnEnable : MonoBehaviour
{

	public GameEvent Event;

	private void OnEnable()
	{
		Event.Raise();
	}
}
