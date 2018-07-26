using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Made By Anthony Romrell
public class AiBehaviour : MonoBehaviour
{
	public Animator Anims;
	public string AnimationName = "Hunt";
	
	void OnEnable ()
	{
		Anims = GetComponent<Animator>();
		Anims.GetBehaviour<AIStates>().Agent = GetComponent<NavMeshAgent>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Anims.SetTrigger(AnimationName);
	}
}
