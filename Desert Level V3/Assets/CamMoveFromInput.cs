using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMoveFromInput : MonoBehaviour
{

	public FloatVariable XMove;
	public FloatVariable ZMove;
	public float xmoveDistance = 2;
	public float zMoveDistance = 3;
	public float returnSpeed = 5;
	private Vector3 moveVector;
	

	public void Move()
	{
		moveVector.x = XMove.FloatValue * xmoveDistance;
		moveVector.z = ZMove.FloatValue * zMoveDistance;
		moveVector.z = Mathf.Clamp(moveVector.z, -zMoveDistance, 0);
		transform.localPosition = moveVector;
	}

	public void Reset()
	{
		StopAllCoroutines();
		StartCoroutine(CameraReset());
	}
	
	private IEnumerator CameraReset()
	{
		while (moveVector.magnitude > .1)
		{
			yield return new WaitForEndOfFrame();
			moveVector -= moveVector * .5f * Time.deltaTime * returnSpeed;
			transform.localPosition = moveVector;
		}
	}
}
