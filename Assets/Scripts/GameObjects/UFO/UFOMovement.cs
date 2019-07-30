using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class UFOMovement : MonoBehaviour, IGameObject
{

	[SerializeField] private float _Speed = 5f;
	
	private Transform _transform;

	private Vector3 _a;
	private Vector3 _b;
	private Vector3 _currentDir;
	
	private bool _isGoingToB = true;

	void Start ()
	{
		_transform = transform;
		var parent = _transform.parent;
		
		_a = parent.GetChild(0).GetChild(0).position;
		_b = parent.GetChild(0).GetChild(1).position;
		
		_currentDir = (_b - _transform.position).normalized;
		Messenger<IGameObject>.Broadcast(EGameEvents.ListenGameObject.ToString(), this);
	}

	public void UpdateObject (float delta)
	{

		_transform.position = _transform.position + _Speed * delta * _currentDir;
		
		ChangeEndPoint();
	}

	private void ChangeEndPoint()
	{
		if (!_isGoingToB && (_transform.position - _a).sqrMagnitude < 0.1f)
		{
			_isGoingToB = true;
			_currentDir = (_b - _transform.position).normalized;
		} 
		else if (_isGoingToB && (_transform.position - _b).sqrMagnitude < 0.1f)
		{
			_isGoingToB = false;
			_currentDir = (_a - _transform.position).normalized;
		}
	}
}
