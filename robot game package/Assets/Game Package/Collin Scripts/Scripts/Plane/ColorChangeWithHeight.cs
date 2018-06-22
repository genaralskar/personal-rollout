using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using genaralskar;

public class ColorChangeWithHeight : MonoBehaviour
{

	public Material playerMat;
	
	public Color planeColor;
	public Color robotColor;
	public Color carColor;

	public float fadeTime = 1;
	
	// Use this for initialization
	private void Start ()
	{
		// EventManager.OnPlayerStatePlane += PlaneStateHandler;
		// EventManager.OnPlayerStateRobot += RobotStateHandler;
		// EventManager.OnPlayerStateCar += CarStateHandler;
	}


	public void PlaneStateHandler()
	{
		StartChangeColor(planeColor);
	}

	public void RobotStateHandler()
	{
		StartChangeColor(robotColor);
	}

	public void CarStateHandler()
	{
		StartChangeColor(carColor);
	}

	private void StartChangeColor(Color newColor)
	{
		StopAllCoroutines();
		StartCoroutine(ChangeColor(newColor));
	}

	private IEnumerator ChangeColor(Color color2)
	{
		print("startinc coroutine");
		float fadeTimer = 0;
		float fadeProgress = 0;

		Color newColor;
		while (fadeProgress < 1)
		{
		//	print(fadeProgress);
			fadeProgress = fadeTimer / fadeTime;
			fadeTimer += Time.deltaTime;
			playerMat.color = Color.Lerp(playerMat.color, color2, fadeProgress);
			yield return new WaitForEndOfFrame();
		}
		
	}
}
