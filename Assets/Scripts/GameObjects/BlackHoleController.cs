using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleController : MonoBehaviour, IGameObject
{
	[SerializeField] private float _MaxDistance = 15;
	[SerializeField] private float _Force = 250;
	[SerializeField] private float _DeadDistance = 0.5f;
	[SerializeField] private float _DistanceCoeff = 10;
	
	private Vector3 _position;
	private PlayerMovement _playerMovement;

// Use this for initialization
	void Start ()
	{
		_playerMovement = FindObjectOfType<PlayerMovement>();
		_position = transform.position;
		Messenger<IGameObject>.Broadcast(GameEvents.ListenGameObject.ToString(), this);
	}


	public void UpdateObject(float delta)
	{
		Vector3 playerPosition = _playerMovement.GetPosition();

		Vector3 dirVector = _position - playerPosition;
		
		if (dirVector.sqrMagnitude > _MaxDistance) 
			return;

		if (dirVector.sqrMagnitude < _DeadDistance)
		{
			_playerMovement.Respawn();
		}
		else
		{
			Rigidbody2D _rb = _playerMovement.GetRigidbody2D();

			_rb.AddForce(_Force * delta * _playerMovement.GetDistanceCoeff(dirVector) * _DistanceCoeff * dirVector);
		}
	}
}
