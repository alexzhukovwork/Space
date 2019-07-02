using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseEvent : MonoBehaviour
{

	[SerializeField] private GameObject menu;

	public void Invoke()
	{
		menu.SetActive(true);
		Time.timeScale = 0;
	}
}
