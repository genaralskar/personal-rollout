using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class CameraFollow : MonoBehaviour
	{

		public Transform objectToTrack;
		private Vector3 offset;

		private void Start()
		{
			offset = transform.position - objectToTrack.position;
		}

		private void LateUpdate()
		{
			transform.position = objectToTrack.position + offset;
		}
	}
}

