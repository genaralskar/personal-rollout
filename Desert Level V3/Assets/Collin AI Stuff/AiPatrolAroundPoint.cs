using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;


//this wont work because it's not different for each ai
public class AiPatrolAroundPoint : AiBase
{

	private Vector3 startingPoint = Vector3.zero;
	private Vector3 randDest;

	private bool startingPointSet = false;
	private bool randDestSet = false;

	private float timer = 0;

	public float patrolRadius = 1;
	public float waitTime = 1;

	private void OnEnable()
	{
		startingPoint = Vector3.zero;
		startingPointSet = false;
		randDest = Vector3.zero;
		randDestSet = false;
	}

	public override void Navigate(NavMeshAgent ai)
	{
		if (!startingPointSet)
		{
			startingPoint = ai.transform.position;
			startingPointSet = true;
		}

		if (!randDestSet)
		{
			randDest = RandomDestination();
			ai.SetDestination(randDest);
			randDestSet = true;
			timer = 0;
		}

		Vector3 posCheck = new Vector3(randDest.x, ai.transform.position.y, randDest.z);
		if (Vector3.Distance(posCheck, randDest) < .1f)
		{
			timer += Time.deltaTime;
			if (timer >= waitTime)
			{
				randDestSet = false;
			}
		}
	}

	private Vector3 RandomDestination()
	{
		Vector3 newDest;

		newDest.y = startingPoint.y;
		newDest.x = startingPoint.x + Random.Range(-patrolRadius, patrolRadius);
		newDest.z = startingPoint.z + Random.Range(-patrolRadius, patrolRadius);
		
		return newDest;
	}

}
