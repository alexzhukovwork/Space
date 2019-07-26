using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

	private PlayerController _playerController;
	
	
	void Awake () {
		Messenger<Vector3>.AddListener(InputEvents.SingleTouch.ToString(), OnClick);
	}

	private void Start()
	{
		_playerController = GetComponent<PlayerController>();
	}

	private void OnClick(Vector3 p)
	{
		_playerController.AddForceFromPoint(p);
	}
}
