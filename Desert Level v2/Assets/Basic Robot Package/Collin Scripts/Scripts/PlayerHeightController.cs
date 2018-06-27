using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Events;


namespace genaralskar
{
	public class PlayerHeightController : MonoBehaviour {
	
		public float transitionDuration = 1f;
		public float carHeight = 2;
		public float robotHeight = 5;
		public float planeHeight = 10;

		private void Start()
		{
		
		}

		public void Height(float height)
		{
			StartCoroutine(ChangeHeight(height));
			
			
		}
	
		private IEnumerator ChangeHeight(float height)
		{
			print("staring corroutine");
			float timer = 0;
			float transitionTime = 0;
			while (transitionTime < 1)
			{
				transitionTime = timer / transitionDuration;
				Vector3 newPos = new Vector3(transform.position.x, Mathf.SmoothStep(transform.position.y, height, timer), transform.position.z);
				transform.position = newPos;
				timer += Time.deltaTime;
				
			//	print("Moving playa");
				yield return new WaitForEndOfFrame();
			}

			transform.position = new Vector3(transform.position.x, height, transform.position.z);
		}
	}
}

