using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Hunt")]

public class AiHunt : AiBase
{
	public GameAction GameAction;
//	public float mindistance;
	
	private Transform Destination;

	private void OnEnable()
	{
		GameAction.Call += Call;
	}

	private void Call(object obj)
	{
		Destination = obj as Transform;
	}

	public override void Navigate(NavMeshAgent ai)
	{
		// if (ai.remainingDistance < mindistance)
        // 	{
		// 		ai.destination = ai.transform.position;
		// 		return;
		// 	}
		ai.destination = (Destination != null ? Destination.position : ai.transform.position);
	}
}