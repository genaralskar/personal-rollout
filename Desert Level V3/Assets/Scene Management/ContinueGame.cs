using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGame : MonoBehaviour
{

	public LevelProgress progress;

	public void Continue()
	{
		SceneManager.LoadScene(progress.currentLevel);
	}
}
