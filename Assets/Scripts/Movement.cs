using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	[SerializeField]
	private float speed;
	
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
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = Vector3.zero;

	/*	if (Input.GetKey(KeyCode.W))
		{
			dir += Vector3.up * speed;
		}
		
		if (Input.GetKey(KeyCode.S))
		{
			dir += Vector3.down * speed;
		}
		
		if (Input.GetKey(KeyCode.D))
		{
			dir += Vector3.right * speed;
		}
		
		if (Input.GetKey(KeyCode.A))
		{
			dir += Vector3.left * speed;
		}
		*/
	//	_rb.AddForce(dir * Time.deltaTime);
		
	/*	if (Input.touchCount > 0)
		{
	//		Debug.Log(Input.GetTouch(0).position);
		}
*/
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Dead"))
			_transform.position = _respawn;
	}

	public void AddForceFromPoint(Vector3 p)
	{
		Debug.Log("Normal " + (_transform.position - p).normalized);
		_rb.AddForceAtPosition((_transform.position - p).normalized * speed*  (1.0f / ((_transform.position - p).magnitude / 5)), p, ForceMode2D.Impulse);
	}
}
