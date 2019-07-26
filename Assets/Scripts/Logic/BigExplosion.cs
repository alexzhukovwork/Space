using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour
{

	[SerializeField] private float _DeadDistance = 1f;

	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.enabled = false;
		Messenger<Vector3>.AddListener(InputEvents.PressTouch.ToString(), Explode);
	}

	private void Explode(Vector3 p)
	{
		
		
		_spriteRenderer.enabled = true;
		transform.position = p;
		
		
		
		
		
		
		
		
		Invoke("Disable", 1);
	}

	private void Disable()
	{
		_spriteRenderer.enabled = false;
		Messenger<Vector3, float>.Broadcast(GameEvents.BigExplosion.ToString(), transform.position, _DeadDistance);
	}
	
}
