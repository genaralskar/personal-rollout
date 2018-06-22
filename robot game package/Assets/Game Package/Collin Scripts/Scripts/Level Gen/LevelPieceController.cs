using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RoboRyanTron.Unite2017.Events;

namespace genaralskar
{
	public class LevelPieceController : MonoBehaviour
	{

		[SerializeField] private float offset;

		public float Offset
		{
			get { return offset; }
		}

		private void OnTriggerExit(Collider other)
		{
			ProceduralLevelGen.OnPieceExit(transform, offset);
		}

	}
}

