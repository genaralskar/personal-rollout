using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Keep Distance")]
public class AiKeepDistance : AiBase
{

	public float distance = 5;
	public StoreTransform playerTransform;

	public override void Navigate(NavMeshAgent ai)
	{
		//get direction from  player to robot
		Vector3 direction = ai.transform.position - playerTransform.transform.position;
		direction = direction.normalized;
		//that vector * disance gives location relative to player for the robots next position
		Vector3 newDest = playerTransform.transform.position + (direction * distance);
//		Debug.Log("Player Transform = " + playerTransform.transform.position);
//		Debug.Log("Direction = " + direction);
//		Debug.Log("Destination = " + newDest);
		ai.SetDestination(newDest);
	}
	
	
}
