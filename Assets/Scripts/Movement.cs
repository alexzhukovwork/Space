using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField] private float speed;

	[SerializeField] private float maxSpeed;

	[SerializeField] private int maxCount = 0;

	[SerializeField] int currentCount = 0;
	
	private Transform _transform;
	private Rigidbody2D _rb;
	private Vector3 _respawn;
	
	// Use this for initialization
	void Start ()
	{
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
		float coeff = 1.0f / position.sqrMagnitude / 10f;
		float currentSpeed = Mathf.Min(coeff * speed, maxSpeed);
		
	//	Debug.Log("Normal " + (_transform.position - p).normalized);
	//	Debug.Log("Distance " + (_transform.position - p).magnitude);
	//	Debug.Log("Distance SQRT " + (_transform.position - p).sqrMagnitude);
		
		Debug.Log("Coeff " + coeff);

		_rb.AddForceAtPosition(currentSpeed * position.normalized, p, ForceMode2D.Impulse);
	}
}
