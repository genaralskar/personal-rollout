using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "Hunt", menuName = "Ai/Function/Patrol")]
public class AiPatrol : AiBase
{
	private int i = 0;

	public GameAction AddPointsToList;
	public GameAction AddPointList;
	
	public List<Transform> PatrolPoints { get ; set; }

	private void OnEnable()
	{
		if (PatrolPoints != null)
		{
			PatrolPoints.Clear();
			AddPointsToList.Call += AddPatrolPoints;
			AddPointList.Call += AddPatrolPointList;
		}
		
	}

	private void AddPatrolPoints(object obj)
	{
		PatrolPoints.Add(obj as Transform);
	}
	
	private void AddPatrolPointList (object obj)
	{
		PatrolPoints = obj as List<Transform>;
	}
	
	public override void Navigate(NavMeshAgent ai)
	{	
		if (ai.remainingDistance < 1)
		{
			ChangePatrolPoint();
		}
		
		ai.destination = PatrolPoints[i].position;
	}

	private void ChangePatrolPoint()
	{
		if (i < PatrolPoints.Count-1)
			i++;
		else
			i = 0;
	}
}