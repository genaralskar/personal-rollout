using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class MissleController : MonoBehaviour, IPooledObject
	{

		private Rigidbody rb;
		private Vector3 currentRotation;
		private Quaternion startRotation;
		[SerializeField] private Transform target;
		public int layerToTarget;
		public float moveSpeed;
		public float rotateSpeed;
		[SerializeField] float targetYOffset = 2;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			currentRotation = transform.forward;
			startRotation = transform.rotation;
		}

		// Use this for initialization
		void OnEnable ()
		{
			FindObjectToTrack();
		}

		private void FindObjectToTrack()
		{
			SetTargetLayer();
			target = FindGameobjectOnLayer(layerToTarget).transform;
			StartCoroutine(TrackObject());
		}

		private IEnumerator TrackObject()
		{
			while(true)
			{
				Vector3 targetPos = target.position - transform.position;
				targetPos.y += targetYOffset;

				Vector3 rotVec = Vector3.RotateTowards(transform.forward, targetPos, rotateSpeed * Time.deltaTime, 0f);
				currentRotation = rotVec;
				transform.rotation = Quaternion.LookRotation(rotVec);
		//		print(rotVec);
				rb.velocity = transform.forward * moveSpeed;
				yield return new WaitForEndOfFrame();
			}
		}

		private void SetTargetLayer()
		{
			if(gameObject.layer == 12)
			{
				layerToTarget = 8;
			}
			else
			{
				layerToTarget = 11;
			}
		}

		private GameObject FindGameobjectOnLayer(int layer)
		{
			GameObject[] objs = FindObjectsOfType<GameObject>();
			foreach(var obj in objs)
			{
				if(obj.layer == layer)
				{
					return obj;
				}
			}
			print("No gameobject on layer " + layer + " found");
			return null;
		}

		public void OnObjectSpawned()
		{
		//	print("bullet OnObjectSpawned spawning!");
			transform.rotation = startRotation;
		}
	}
}

