using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEvent : MonoBehaviour {

	[SerializeField] private Rigidbody2D _Rb;
	
	private Transform _transform;
	private Vector3 _respawn;


	private void Awake()
	{
		Messenger.AddListener(EGameEvents.Dead.ToString(), Respawn);
	}

	void Start () {
		_transform = transform.parent;
		_respawn = _transform.position;
	}
	
	public void Respawn()
	{
		Messenger.Broadcast(EGameEvents.Respanw.ToString());
		_transform.position = _respawn;
		_Rb.velocity = Vector3.zero;
	}
}
