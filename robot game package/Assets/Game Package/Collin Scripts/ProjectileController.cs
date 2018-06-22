using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

	[SerializeField] private bool disableOnHit = true;

	public void LifetimeDisable(float time)
	{
		StartCoroutine(DisableAfterLifetime(time));
	}
		
	private IEnumerator DisableAfterLifetime(float time)
	{
		yield return new WaitForSeconds(time);
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter()
	{
		gameObject.SetActive(false);
	}
}
