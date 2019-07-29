using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneClickHandler : MonoBehaviour
{

	[SerializeField] private float _Force = 40;
	
	[SerializeField] private MovementController _movementController;

	void Awake () {
		Messenger<Vector3>.AddListener(InputEvents.SingleTouch.ToString(), OnClick);
	}

	private void OnClick(Vector3 p)
	{
		_movementController.AddForceFromPoint(p, _Force);
	}
}
