﻿using UnityEngine;

namespace genaralskar
{
	public class DestructableObject : MonoBehaviour
	{
	
		public GameObject undestroyedObj;
		public GameObject destroyedObj;
		public DestructableObjectDatabase database;
		private bool destroyed = false;
	
		private void OnEnable()
		{
			database.RegisterObject(this, destroyed);
			GetState();
			UpdateGameObjects();
		}
	
		public void ChangeState(bool newState)
		{
			destroyed = newState;
			database.UpdateObject(this, newState);
			UpdateGameObjects();
		}
	
		public void GetState()
		{
			destroyed = database.ReturnState(this);
		}
	
		private void UpdateGameObjects()
		{
			destroyedObj.SetActive(destroyed);
			undestroyedObj.SetActive(!destroyed);
		}
	}
}
