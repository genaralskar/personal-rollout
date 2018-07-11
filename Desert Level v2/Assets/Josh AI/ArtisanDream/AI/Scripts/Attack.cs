using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public Animator Anims;
	public string AnimationName1 = "Attack";
	public string AnimationName2 = "Hunt";
	public GameObject Enemy;
	
	void Awake ()
	{
//		Anims = GetComponent<Animator>();
		Anims.GetBehaviour<AIStates>().Agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

	private void OnTriggerEnter(Collider other)
	{
		Anims.SetTrigger(AnimationName1);	
	}

	private void OnTriggerExit(Collider other)
	{
		Anims.SetTrigger(AnimationName2);
	}
}