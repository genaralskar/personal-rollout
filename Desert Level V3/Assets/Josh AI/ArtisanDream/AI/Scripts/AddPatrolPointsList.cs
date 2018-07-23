using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Made By Anthony Romrell
public class AddPatrolPointsList : MonoBehaviour
{

	public List<Transform> PatrolPoints;
	
	public GameAction SendAction;

	private void Start()
	{
		SendAction.Call(PatrolPoints);
	}

}
