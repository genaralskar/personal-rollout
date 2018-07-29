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


	public EnemyHealthManagerMono healthManager;

	private void Start()
	{
        PopulateDictionary();
		healthManager = gameObject.GetComponent<EnemyHealthManagerMono>();
		Debug.Log(healthManager);
		healthManager.manager.healthUpdate += StartFlash;
	}

    private void PopulateDictionary()
    {
        matDic = new Dictionary<Renderer, Material>();

//        if(!flashObjects.Contains(gameObject))
//        {
//            flashObjects.Add(gameObject);
//        }

        foreach(GameObject obj in flashObjects)
        {
            matDic.Add(obj.GetComponent<Renderer>(), obj.GetComponent<Renderer>().material);
        }
    }

	
	//instead of on damage, on health update
	private void StartFlash(float newHealth)
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
