﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour, IGameObject
{
	[SerializeField] private float _MaxDistance = 15;
	[SerializeField] private float _Force = 250;
	[SerializeField] private float _DeadDistance = 0.5f;
	[SerializeField] private float _DistanceCoeff = 10;
	
	private Vector3 _position;
	private MovementController _movementController;

// Use this for initialization
	void Start ()
	{
		_movementController = FindObjectOfType<MovementController>();
		_position = transform.position;
		Messenger<IGameObject>.Broadcast(EGameEvents.ListenGameObject.ToString(), this);
	}


	public void UpdateObject(float delta)
	{
		Vector3 playerPosition = _movementController.GetPosition();

		Vector3 dirVector = _position - playerPosition;
		
		if (dirVector.sqrMagnitude > _MaxDistance) 
			return;

		if (dirVector.sqrMagnitude < _DeadDistance)
		{
			Messenger.Broadcast(EGameEvents.Dead.ToString());
		}
		else
		{
			Rigidbody2D _rb = _movementController.GetRigidbody2D();

			_rb.AddForce(_Force * delta * _movementController.GetDistanceCoeff(dirVector) * _DistanceCoeff * dirVector);
		}
	}
}
