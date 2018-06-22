using UnityEngine;

[CreateAssetMenu(fileName = "MovePatternBase")]
public abstract class MovePatternBase : ScriptableObject 
{
	public float speed = 6.0F;
	public float gravity = 20.0F;
	
	protected Vector3 moveDirection;
	protected Vector3 rotateDirection;

	public InputBase InputX, InputY, InputZ;
	
	public InputBase InputRotateX, InputRotateY, InputRotateZ;
	
	public InputBase JumpInput;

	public abstract void Move(CharacterController controller, Transform transform);
}