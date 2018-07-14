using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFlash : MonoBehaviour
{

	public Material matOverride;
	private Material startMat;
	private Renderer mat;

	public float flashTime = .1f;

	public int flashNumber = 1;

	private void Start()
	{
		mat = GetComponent<Renderer>();
		startMat = mat.material;
	}

	private void OnParticleCollision(GameObject other)
	{
		print("Flashing");
		StopAllCoroutines();
		StartCoroutine(Flash());
	}

	private IEnumerator Flash()
	{

		for (int i = 0; i < flashNumber; i++)
		{
			mat.material = matOverride;
			yield return new WaitForSeconds(flashTime);
			mat.material = startMat;
			yield return new WaitForSeconds(flashTime);	
		}
		
	}
}
