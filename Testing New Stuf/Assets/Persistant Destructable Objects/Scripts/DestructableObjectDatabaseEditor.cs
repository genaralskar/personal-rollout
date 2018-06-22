
using UnityEngine;
using UnityEditor;

namespace genaralskar
{
	[CustomEditor(typeof(DestructableObjectDatabase))]
	public class DestructableObjectDatabaseEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			DestructableObjectDatabase d = target as DestructableObjectDatabase;
			if (GUILayout.Button("Clear Database (Can't Undo, Be Careful!)"))
				d.ResetDatabase();
		}
	}
}
