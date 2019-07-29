using System;
using UnityEngine;

public class BigExplosion : MonoBehaviour
{

	[SerializeField] private float _DeadSqrDistance = 25f;
	[SerializeField] private float _Force = 10f;
	[SerializeField] private int _Count = 5;

	private int _currentCount;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_spriteRenderer.enabled = false;
		Messenger<Vector3>.AddListener(EInputEvents.PressTouch.ToString(), Explode);
		
		//TODO Call another event...
		Messenger.AddListener(EGameEvents.Respanw.ToString(), Respawn);
	}

	private void OnDestroy()
	{
		Messenger<Vector3>.RemoveListener(EInputEvents.PressTouch.ToString(), Explode);
		Messenger.RemoveListener(EGameEvents.Respanw.ToString(), Respawn);
	}

	private void Start()
	{
		Respawn();
	}

	private void Explode(Vector3 p)
	{
		if (_currentCount <= 0)
			return;
		
		_spriteRenderer.enabled = true;
		transform.position = p;

		Invoke("Disable", 1);
		_currentCount--;
	}
	
	private void Respawn()
	{
		_currentCount = _Count;
	}

	private void Disable()
	{
		_spriteRenderer.enabled = false;
		Messenger<Vector3, float, float>.Broadcast(EGameEvents.BigExplosion.ToString(), transform.position, _DeadSqrDistance, _Force);
	}
	
}
