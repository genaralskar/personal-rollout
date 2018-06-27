using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class RotateToInput : MonoBehaviour
	{

		public InputBase floatX;
		public InputBase floatY;
		public InputBase floatZ;

		private Quaternion startRot;

		private void Start()
		{
			startRot = transform.rotation;
		}

		public void Rotate()
		{
			Vector3 rotVector = new Vector3(floatX.SetFloat() + transform.localPosition.x, 
											floatY.SetFloat() + transform.localPosition.y,
											floatZ.SetFloat() + transform.localPosition.z);
			
			print(rotVector);
			transform.LookAt(rotVector);
		}

		public void ResetRotation()
		{
			transform.rotation = startRot;
		}
	}
}

