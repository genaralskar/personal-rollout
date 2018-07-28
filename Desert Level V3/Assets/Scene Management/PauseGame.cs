﻿using UnityEngine;


public class PauseGame : MonoBehaviour {

	public void Pause()
	{
		Time.timeScale = 0;
	}

	public void UnPause()
	{
		Time.timeScale = 1;
	}

}
