using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExplosion : MonoBehaviour
{

	[SerializeField] private float _Force = 40;
	

	void Awake () {
		Messenger<Vector3>.AddListener(EInputEvents.SingleTouch.ToString(), OnClick);
	}

	private void OnDestroy()
	{
		Messenger<Vector3>.RemoveListener(EInputEvents.SingleTouch.ToString(), OnClick);
	}

	private void OnClick(Vector3 p)
	{
		Messenger<Vector3, float>.Broadcast(EGameEvents.SimpleExplosion.ToString(), p, _Force);
	}
}
