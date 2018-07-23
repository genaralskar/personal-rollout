using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using RoboRyanTron.Unite2017.Events;
using UnityEditor;
using UnityEngine;

public class MoveCameraBack : MonoBehaviour
{

	public CinemachineMixingCamera mixer;
	public FloatVariable zAim;
	public float returnSpeed = 3;

	public void MoveCamera () 
	{
		
		print("moving Camera!");
		if (zAim.SetFloat() < 0)
			mixer.m_Weight1 = -zAim.SetFloat();
		else
		{
			mixer.m_Weight1 = 0;
		}

	}

	public void ResetCamera()
	{
		print("Resetnig Camera");
		StopAllCoroutines();
		StartCoroutine(CameraReset());
	}

	private IEnumerator CameraReset()
	{
		while (mixer.m_Weight1 > .1)
		{
			yield return new WaitForEndOfFrame();
			mixer.m_Weight1 -= mixer.m_Weight1 * .5f * Time.deltaTime * returnSpeed;
		}
	}
}
