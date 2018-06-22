using System.Collections.Generic;
using UnityEngine;

namespace genaralskar
{
	[CreateAssetMenu(menuName = "Destructable Object Database")]
	public class DestructableObjectDatabase : ScriptableObject
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
	
		public void RegisterObject(DestructableObject obj, bool state)
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
	
	
		public bool ReturnState(DestructableObject obj)
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
	
		public void UpdateObject(DestructableObject obj, bool newState)
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
	
		private ObjState ReturnObjState(DestructableObject obj)
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
		public DestructableObject obj;
		public bool state;
	
		public ObjState(DestructableObject obj, bool state)
		{
			this.obj = obj;
			this.state = state;
		}
	}
}