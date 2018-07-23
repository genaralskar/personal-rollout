using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

namespace genaralskar
{
	public class RotateToInput : MonoBehaviour
	{

		public InputBase floatX;
		public InputBase floatY;
		public InputBase floatZ;

		

		private Quaternion startRot;
		private float startCamPos;
		
		private void Start()
		{
			startRot = transform.rotation;
		}

		public void Rotate()
		{
			Vector3 rotVector = new Vector3(floatX.SetFloat() + transform.position.x,
											floatY.SetFloat() + transform.position.y,
											floatZ.SetFloat() + transform.position.z);
			
//			print(rotVector);
			transform.LookAt(rotVector);
		}

		public void ResetRotation()
		{
			transform.rotation = startRot;
		}
	}
}

