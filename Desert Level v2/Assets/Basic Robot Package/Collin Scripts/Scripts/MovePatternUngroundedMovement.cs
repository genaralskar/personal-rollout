using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "genaralskar/MovePatternUngroundedMovement")]
public class MovePatternUngroundedMovement : MovePatternBase
{
	private float gravityTimer = 0;
	
	public override void Move(CharacterController controller, Transform transform)
	{
		
		rotateDirection.Set(InputRotateX.SetFloat(), InputRotateY.SetFloat(), InputRotateZ.SetFloat());
		transform.Rotate(rotateDirection);
		
		moveDirection.Set(InputX.SetFloat(), InputY.SetFloat(), InputZ.SetFloat()); //changed y from InputY.SetFloat()
		
		
		if (!controller.isGrounded)
		{
			gravityTimer += Time.deltaTime;
			moveDirection.y -= gravity * (gravityTimer + Time.deltaTime);
			Debug.Log("Gravity!");
		}
		else
		{
			gravityTimer = 0;
		}
		
		moveDirection = transform.TransformDirection(moveDirection);
		
		moveDirection *= speed;	
		
		if(JumpInput.SetFloat() != 0)
			moveDirection.y = JumpInput.SetFloat();

		//Debug.Log(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);
	}	
}