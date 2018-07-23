using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransformStore : MonoBehaviour
{

	public StoreTransform transformStore;

	private void Start()
	{
		transformStore.transform = this.transform;
	}
}
