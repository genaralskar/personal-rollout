using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Attack", menuName = "Ai/Function/Attack")]

public class AiHuntAttack : AiBase
{
	public GameAction GameAction;
	
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
		if (ai.remainingDistance <= 3)
		{
			AttackPlayer();
		}
		ai.destination = (Destination != null ? Destination.position : ai.transform.position);
	}

	private void AttackPlayer()
		{
			Debug.Log("attack");
		}
}