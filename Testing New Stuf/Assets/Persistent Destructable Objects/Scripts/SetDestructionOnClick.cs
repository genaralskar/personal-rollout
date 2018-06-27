﻿using System.Collections;
using System.Collections.Generic;
using genaralskar;
using UnityEngine;

public class SetDestructionOnClick : MonoBehaviour
{
	public DestructibleObject obj;
	public bool setDestruction = true;

	private void OnMouseDown()
	{
		obj.ChangeState(setDestruction);
	}
}