using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFlash : MonoBehaviour
{

	public Material flashMaterial;

	public float flashTime = .1f;

	public int flashNumber = 1;

    public List<GameObject> flashObjects;

    private Dictionary<Renderer, Material> matDic;

	private void Start()
	{
        PopulateDictionary();
	}

    private void PopulateDictionary()
    {
        matDic = new Dictionary<Renderer, Material>();

        if(!flashObjects.Contains(gameObject))
        {
            flashObjects.Add(gameObject);
        }

        foreach(GameObject obj in flashObjects)
        {
            matDic.Add(obj.GetComponent<Renderer>(), obj.GetComponent<Renderer>().material);
        }
    }

	private void OnParticleCollision(GameObject other)
	{
	//	print("Flashing");
		StopAllCoroutines();
		StartCoroutine(Flash());
	}

    private void OnParticleTrigger()
    {
        StopAllCoroutines();
        StartCoroutine(Flash());
    }

    private IEnumerator Flash()
	{
		for (int i = 0; i < flashNumber; i++)
		{
            foreach(GameObject obj in flashObjects)
            {
                obj.GetComponent<Renderer>().material = flashMaterial;
            }
			yield return new WaitForSeconds(flashTime);
            foreach(GameObject obj in flashObjects)
            {
                obj.GetComponent<Renderer>().material = matDic[obj.GetComponent<Renderer>()];
            }
			yield return new WaitForSeconds(flashTime);	
		}	
	}
}
