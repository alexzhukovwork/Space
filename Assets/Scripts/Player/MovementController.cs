using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class MovementController : MonoBehaviour
{
	[SerializeField] private float _CoeffDistance = 10;

	[SerializeField] private float _MinSqrDistanceToPlayer = 0.25f;
	
	[SerializeField] private Vector3 _MaxVelocity = new Vector3(10, 10);
	
	private Vector3[] _axeses;
	
	private Transform _transform;
	private Rigidbody2D _rb;


	private void Awake()
	{
		Messenger<Vector3, float>.AddListener(GameEvents.BigExplosion.ToString(), BigExplode);
	}

	private void Start ()
	{
		_axeses = new Vector3[8];
		
		_axeses[0] = new Vector3(0, 1);
		_axeses[1] = new Vector3(0, -1);
		_axeses[2] = new Vector3(1, 1);
		_axeses[3] = new Vector3(1, -1);
		_axeses[4] = new Vector3(-1, 1);
		_axeses[5] = new Vector3(-1, -1);
		_axeses[6] = new Vector3(1, 0);
		_axeses[7] = new Vector3(-1, 0);
		
		_transform = transform;
		_rb = GetComponent<Rigidbody2D>();
	}

	public void AddForceFromPoint(Vector3 p, float force)
	{
		p.z = 0;
		Vector3 position = _transform.position - p;
		float coeff = GetDistanceCoeff(position);
		float currentSpeed = coeff * force;

		Vector3 axes = GetAxes(position.normalized);

		_rb.AddForce(currentSpeed * axes, ForceMode2D.Impulse);
		
		if (_rb.velocity.x * _rb.velocity.x > _MaxVelocity.x * _MaxVelocity.x)
			_rb.velocity = new Vector3(_MaxVelocity.x * (_rb.velocity.x < 0 ? -1 : 1), _rb.velocity.y);
		
		if (_rb.velocity.y * _rb.velocity.y > _MaxVelocity.y * _MaxVelocity.y)
			_rb.velocity = new Vector3(_rb.velocity.x, _MaxVelocity.y * (_rb.velocity.y < 0 ? -1 : 1));
	}

	public float GetDistanceCoeff(Vector3 position)
	{
		return 1.0f / Mathf.Max(position.sqrMagnitude, _MinSqrDistanceToPlayer) / _CoeffDistance;
	}

	private void BigExplode(Vector3 p, float deadDistance)
	{
		if ((p - _transform.position).sqrMagnitude > deadDistance)
		{
			AddForceFromPoint(p, 0);
		}
		else
		{
			Messenger.Broadcast(GameEvents.Dead.ToString());
		}
	}

	private Vector3 GetAxes(Vector3 p)
	{
		int minI = 0;

		float minValue = 100;

		float temp = 0;
		
		for (int i = 0; i < _axeses.Length; i++)
		{
			if ((temp = (_axeses[i] - p).sqrMagnitude) < minValue)
			{
				minValue = temp;
				minI = i;
			}
		}

		return _axeses[minI];
	}
	
	#region Get
	
	public Vector3 GetPosition()
	{
		return _transform.position;
	}

	public Rigidbody2D GetRigidbody2D()
	{
		return _rb;
	}

	#endregion
}
