using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public void Change(int newScene)
     	{
     		SceneManager.LoadScene(newScene);
     	}
	
	public void Change(string newScene)
	{
		SceneManager.LoadScene(newScene);
	}
	
}
