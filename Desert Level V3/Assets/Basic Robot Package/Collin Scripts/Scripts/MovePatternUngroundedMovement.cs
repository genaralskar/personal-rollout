using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "genaralskar/MovePatternUngroundedMovement")]
public class MovePatternUngroundedMovement : MovePatternBase {

    public FloatVariable moveSpeedMultiplier;

	public override void Move(CharacterController controller, Transform transform)
	{
		
		rotateDirection.Set(InputRotateX.SetFloat(), InputRotateY.SetFloat(), InputRotateZ.SetFloat());
		transform.Rotate(rotateDirection);
		
		moveDirection.Set(InputX.SetFloat(), InputY.SetFloat(), InputZ.SetFloat()); //changed y from InputY.SetFloat()
		if (!controller.isGrounded)
		{
			moveDirection.y -= gravity * Time.deltaTime;
//			Debug.Log("Gravity!" + moveDirection.y);
		}
		
		moveDirection = transform.TransformDirection(moveDirection);
		
        if(moveSpeedMultiplier != null)
        {
            moveDirection *= speed * moveSpeedMultiplier.FloatValue;
        }
        else
        {
            moveDirection *= speed;
        }
		
		if(JumpInput.SetFloat() != 0)
			moveDirection.y = JumpInput.SetFloat();

		//Debug.Log(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);
	}	
}