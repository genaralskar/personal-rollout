using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "genaralskar/MovePatternGravity")]
public class MovePatternGravity : MovePatternBase {

	public override void Move(CharacterController controller, Transform transform)
	{
		if (!controller.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
		}
		
		rotateDirection.Set(InputRotateX.SetFloat(), InputRotateY.SetFloat(), InputRotateZ.SetFloat());
		transform.Rotate(rotateDirection);
		
		moveDirection.Set(InputX.SetFloat(),InputY.SetFloat(),InputZ.SetFloat());
		moveDirection = transform.TransformDirection(moveDirection);
		
		moveDirection *= speed;	
		
		if(JumpInput.SetFloat() != 0)
			moveDirection.y = JumpInput.SetFloat();

		//Debug.Log(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);
	}	
}