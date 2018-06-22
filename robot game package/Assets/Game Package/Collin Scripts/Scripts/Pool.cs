using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	[CreateAssetMenu(menuName = "genaralskar/GameObject Pool")]
	public class Pool : ScriptableObject {
	
		public GameObject prefab;
		public int size;
		private Queue<GameObject> objectPool;
	
		public void FillPool()
		{
			objectPool = new Queue<GameObject>();
			for (int i = 0; i < size; i++)
			{
				GameObject temp = Instantiate(prefab);
				temp.SetActive(false);
				objectPool.Enqueue(temp);
			}
		}
	
		public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation)
		{
			GameObject objectToSpawn = objectPool.Dequeue();
			objectToSpawn.transform.position = position;
			objectToSpawn.transform.rotation = rotation;
			objectToSpawn.SetActive(true);

			IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
			if (pooledObj != null)
			{
				pooledObj.OnObjectSpawned();
			}
			
			objectPool.Enqueue(objectToSpawn);
			return objectToSpawn;
		}
		
		public GameObject GetObjectFromPool(Vector3 position, Quaternion rotation, int layerIndex) //use to set layer of object
		{
			GameObject objectToSpawn = objectPool.Dequeue();
			objectToSpawn.transform.position = position;
			objectToSpawn.transform.rotation = rotation * objectToSpawn.transform.rotation;
			objectToSpawn.layer = layerIndex;
			objectToSpawn.SetActive(true);
			
			IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
			if (pooledObj != null)
			{
				pooledObj.OnObjectSpawned();
			}
			
			objectPool.Enqueue(objectToSpawn);
			return objectToSpawn;
		}
		
		//add methods that dont return gameobject, that don't need position/rotation
	}
}

