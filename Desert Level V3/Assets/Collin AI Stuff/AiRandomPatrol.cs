using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

[CreateAssetMenu(menuName = "AI/Random Patrol")]
//this wont work because it's not different for each ai
public class AiRandomPatrol : AiBase
{

	private Vector3 randDest;

	private bool randDestSet = false;

	private float timer = 0;
	
	public float patrolRadius = 1;
	public float waitTime = 1;

	private void OnEnable()
	{
		randDest = Vector3.zero;
		randDestSet = false;
	}

	public override void Navigate(NavMeshAgent ai)
	{

		if (!randDestSet)
		{
			randDest = RandomDestination(ai.transform);
			ai.SetDestination(randDest);
			randDestSet = true;
			timer = 0;
		}

		Debug.Log(Vector3.Distance(ai.transform.position, randDest));
		if (Vector3.Distance(ai.transform.position, randDest) < 1f)
		{
			timer += Time.deltaTime;
			if (timer >= waitTime)
			{
				randDestSet = false;
			}
		}
	}

	private Vector3 RandomDestination(Transform t)
	{
		Vector3 newDest;
		
		NavMeshHit hit;
		do
		{
			newDest.y = t.position.y;
			newDest.x = t.position.x + Random.Range(-patrolRadius, patrolRadius);
			newDest.z = t.position.z + Random.Range(-patrolRadius, patrolRadius);
		} while (!NavMesh.SamplePosition(newDest, out hit, 1.0f, NavMesh.AllAreas)); //checks if new destination is on the navmesh
		
		Debug.Log("new destination found: " + newDest);
		return newDest;
	}

}
