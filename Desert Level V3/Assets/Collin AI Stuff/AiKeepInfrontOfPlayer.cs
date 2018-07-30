using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "AI/Keep In Front Of Player")]
public class BallShipAI : AiBase
{

	public StoreTransform playerTransform;
	public float offset;
	
	public override void Navigate(NavMeshAgent ai)
	{
		ai.SetDestination(FindPos(ai));
	}

	private Vector3 FindPos(NavMeshAgent ai)
	{
		Vector3 newPos = new Vector3(ai.transform.position.x, ai.transform.position.y,
			playerTransform.transform.position.z + offset);
		return newPos;
	}

}
