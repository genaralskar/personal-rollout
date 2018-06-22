using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	[CreateAssetMenu(menuName = "Destructible Object Database")]
	public class DestructibleObjectDatabase : ScriptableObject
	{
	
		private List<ObjState> database;
		private List<ObjState> checkList; //used to remove objects that are no longer in the scene from the database
	
		private void OnEnable()
		{
			if (database == null)
			{
				ResetDatabase();
			}
			checkList = new List<ObjState>(database);	
		}
	
		public void RegisterObject(DestructibleObject obj, bool state)
		{
			if (ReturnObjState(obj) == null)
			{
				database.Add(new ObjState(obj, state));
			}
			else
			{
				checkList.Remove(ReturnObjState(obj));
			}
		}
	
		private void CleanDatabase()
		{
			for (int i = checkList.Count - 1; i >= 0; i--)
			{
				database.Remove(checkList[i]);
				checkList.RemoveAt(i);
			}
		}
	
	
		public bool ReturnState(DestructibleObject obj)
		{
			ObjState tempState = ReturnObjState(obj);
			if (tempState != null)
			{
				return tempState.state;
			}
			else
			{
				return false;
			}
		}
	
		public void UpdateObject(DestructibleObject obj, bool newState)
		{
			ObjState tempState = ReturnObjState(obj);
			if (tempState != null)
			{
				ReturnObjState(obj).state = newState;
			}
			else
			{
				RegisterObject(obj, newState);
			}
			if (checkList.Count > 0)
			{
				CleanDatabase();
			}
		}
	
		[ExecuteInEditMode]
		public void ResetDatabase()
		{
			database = new List<ObjState>();
		}
	
		private ObjState ReturnObjState(DestructibleObject obj)
		{
			foreach (var objState in database)
			{
				if (objState.obj == obj)
				{
					return objState;
				}
			}
			return null;
		}
	}
	
	[System.Serializable]
	public class ObjState
	{
		public DestructibleObject obj;
		public bool state;
	
		public ObjState(DestructibleObject obj, bool state)
		{
			this.obj = obj;
			this.state = state;
		}
	}
}