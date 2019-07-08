using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebClientSDK.Scripts.StateMachine;

public class MouseController : MonoBehaviour
{
	[SerializeField] private bool isAndroid = false;
	
	private Movement _movement;
	// Use this for initialization
	void Start ()
	{
		_movement = FindObjectOfType<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
	//	if (AppStateManager.Instance.CurrentlyApplicationState == States.StateApp.Menu)
	//		return;
	
		if (!isAndroid && Input.GetMouseButtonDown(0))
		{
			Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Debug.Log(p);
			
			_movement.AddForceFromPoint(p);
			
		} 
		else if (isAndroid && Input.touchCount > 0)
		{
			Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

			Debug.Log(p);
			
			_movement.AddForceFromPoint(p);
		}
	}
}
