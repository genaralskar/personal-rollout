
using UnityEngine;
using UnityEditor;

namespace genaralskar
{
	[CustomEditor(typeof(DestructibleObjectDatabase))]
	public class DestructibleObjectDatabaseEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			DestructibleObjectDatabase d = target as DestructibleObjectDatabase;
			if (GUILayout.Button("Clear Database (Can't Undo, Be Careful!)"))
				d.ResetDatabase();
		}
	}
}
