using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChangeMovementType : MonoBehaviour
{

	public Player player;
	
	public void ChangeMovement(MovePatternBase moveBehaviour)
	{
		player.PlayerMovePattern = moveBehaviour;
	}
	
}
