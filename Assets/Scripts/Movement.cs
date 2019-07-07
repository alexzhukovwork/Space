using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Movement : MonoBehaviour
{
	[SerializeField] private float force;

	[SerializeField] private float maxForce;

	[SerializeField] private int maxCount = 0;

	[SerializeField] private int currentCount = 0;

	[SerializeField] private float coeffDistance = 10;
	
	[SerializeField] private Vector3 maxVelocity = new Vector3(10, 10);
	
	private Vector3[] _axes;
	
	private Transform _transform;
	private Rigidbody2D _rb;
	private Vector3 _respawn;
	
	// Use this for initialization
	void Start ()
	{
		_axes = new Vector3[8];
		
		_axes[0] = new Vector3(0, 1);
		_axes[1] = new Vector3(0, -1);
		_axes[2] = new Vector3(1, 1);
		_axes[3] = new Vector3(1, -1);
		_axes[4] = new Vector3(-1, 1);
		_axes[5] = new Vector3(-1, -1);
		_axes[6] = new Vector3(1, 0);
		_axes[7] = new Vector3(-1, 0);
		
		_transform = transform;
		_rb = GetComponent<Rigidbody2D>();
		_respawn = _transform.position;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Dead"))
		{
			_transform.position = _respawn;
			currentCount = 0;
		}
	}

	public void AddForceFromPoint(Vector3 p)
	{
		if (maxCount != 0 && currentCount >= maxCount)
			return;
		
		if (maxCount != 0)
			currentCount++;
		
		p.z = 0;
		Vector3 position = _transform.position - p;
		float coeff = 1.0f / position.sqrMagnitude / coeffDistance;
		float currentSpeed = Mathf.Min(coeff * force, maxForce);
		

		_rb.AddForceAtPosition(currentSpeed * position.normalized, GetAxe(position.normalized), ForceMode2D.Impulse);
		
		if (_rb.velocity.x * _rb.velocity.x > maxVelocity.x * maxVelocity.x)
			_rb.velocity = new Vector3(maxVelocity.x, _rb.velocity.y);
		
		if (_rb.velocity.y * _rb.velocity.y > maxVelocity.y * maxVelocity.y)
			_rb.velocity = new Vector3(_rb.velocity.x, maxVelocity.y);
		
		Debug.Log(Time.time + " Velocity " +  _rb.velocity);

	}

	private Vector3 GetAxe(Vector3 p)
	{
		int minI = 0;

		float minValue = 100;

		float temp = 0;
		
		for (int i = 0; i < _axes.Length; i++)
		{
			if ((temp = (_axes[i] - p).sqrMagnitude) < minValue)
			{
				minValue = temp;
				minI = i;
			}
		}

		return _axes[minI];
	}
}
