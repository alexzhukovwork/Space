using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneEvent : MonoBehaviour
{

	[SerializeField] private string sceneName;
	
	public void Invoke()
	{
		SceneManager.LoadScene(sceneName);
	}
}
