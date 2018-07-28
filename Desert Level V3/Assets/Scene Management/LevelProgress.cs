using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Level/Progress")]
public class LevelProgress : ScriptableObject
{

	public string[] levelSceneNames;

	public int currentLevel = 1;

	public Levels[] completedLevels;

}

[System.Serializable]
public class Levels
{
	public string levelName;
	public bool completed;
}
