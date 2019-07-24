using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour
{

	[SerializeField] private float _DeadDistance = 1f;

	private void Awake()
	{
		Messenger<Vector3>.AddListener(InputEvents.PressTouch.ToString(), Explode);
	}

	private void Explode(Vector3 p)
	{
		Messenger<Vector3, float>.Broadcast(GameEvents.BigExplosion.ToString(), p, _DeadDistance);
	}
	
}
