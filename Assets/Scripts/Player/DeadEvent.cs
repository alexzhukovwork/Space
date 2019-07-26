using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEvent : MonoBehaviour {

	private Transform _transform;
	private Rigidbody2D _rb;
	private Vector3 _respawn;


	private void Awake()
	{
		Messenger.AddListener(GameEvents.Dead.ToString(), Respawn);
	}

	void Start () {
		_transform = transform;
		_rb = GetComponent<Rigidbody2D>();
		_respawn = _transform.position;
	}
	
	public void Respawn()
	{
		_transform.position = _respawn;
		_rb.velocity = Vector3.zero;
	}
}
