using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebClientSDK.Scripts.StateMachine;

public class MouseController : MonoBehaviour, IGameObject
{
	[SerializeField] private bool _IsAndroid = false;
	[SerializeField] private float _TimePressed = 0.3f;
	
	private float _lastTime = 0;
	private float _timePressed = 0;
	private int _countClick = 0;

	private bool _isDown = false;
	private bool _wasDown = false;
	
	private Vector3 _lastInput;
	
	
	// Use this for initialization
	void Start ()
	{
		Messenger<IGameObject>.Broadcast(EGameEvents.ListenGameObject.ToString(), this);
	}
	
	// Update is called once per frame
	void IGameObject.UpdateObject (float delta) {
	//	if (AppStateManager.Instance.CurrentlyApplicationState == States.StateApp.Menu)
	//		return;
	
		if (Input.GetMouseButtonUp(0))
		{
		/*	if (_countClick == 1 && Time.time - _lastTime < _TimeDoubleClick)
			{
				_countClick = 0;
				Debug.Log("DOUBLE");
			}
			else if (_countClick == 0)
			{
				_countClick++;	
			}

			
			_lastTime = Time.time;*/
		
		
			_timePressed = 0;
			_isDown = false;
			
			
			if (!_wasDown)
				Messenger<Vector3>.Broadcast(EInputEvents.SingleTouch.ToString(), _lastInput);

		}

		/*if (_countClick != 0 && Time.time - _lastTime > _TimeDoubleClick)
		{
			Debug.Log("SIMPLE");
			_countClick = 0;
			
		}*/

		if (Input.GetMouseButtonDown(0))
		{
			_lastInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_lastInput.z = 0;
			_isDown = true;
			_wasDown = false;
		}

		if (_isDown)
			_timePressed += Time.deltaTime;
		
		if (_timePressed > _TimePressed)
		{
			Messenger<Vector3>.Broadcast(EInputEvents.PressTouch.ToString(), _lastInput);
			
			_timePressed = 0;
			_isDown = false;
			_wasDown = true;
		}
	}
}
