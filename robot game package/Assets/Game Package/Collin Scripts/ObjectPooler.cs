using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	public class ObjectPooler : MonoBehaviour
	{
		[SerializeField] private List<Pool> pools;
	
		private void Start()
		{
			foreach (var pool in pools)
			{
				pool.FillPool();
			}
		}
	}
}

