using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

	[Tooltip("The variable to store the X value")]
	public FloatVariable xInput;
	[Tooltip("The variable to store the Y value")]
	public FloatVariable yInput;
	[Tooltip("The distance the joystick can move from it's staring point")]
	public float movementRange = 50;

	private Vector3 startPosition;
	private Vector3 inputVector;

	private void Start()
	{
		startPosition = transform.position;
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 newPos = Vector3.zero;
		
		int deltaX = (int)(eventData.position.x - startPosition.x);
		newPos.x = deltaX;
		
		int deltaY = (int)(eventData.position.y - startPosition.y);
		newPos.y = deltaY;
		
		transform.position = Vector3.ClampMagnitude(new Vector3( newPos.x, newPos.y, newPos.z), movementRange) + startPosition;
		
		inputVector = Vector3.ClampMagnitude(new Vector3(deltaX, deltaY, 0), movementRange);
		inputVector /= movementRange;
	//	print(inputVector);

		xInput.FloatValue = inputVector.x;
		yInput.FloatValue = inputVector.y;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		transform.position = startPosition;
		xInput.FloatValue = 0;
		yInput.FloatValue = 0;
	}

	public void OnPointerDown(PointerEventData eventData) //needed so OnPointerUp works
	{

	}
}
