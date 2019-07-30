using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsController : MonoBehaviour
{

	[SerializeField] private float _CoolDown = 1f;
	[SerializeField] private float _BulletSpeed = 5;
	[SerializeField] private float _MaxBulletSqrDistance = 100f;
	[SerializeField] private float _RadiusSqrDistanceToPlayer = 49f;
	
	private List<Bullet> _bullets;
	private MovementController _movementController;

	private Transform _transform;

	private void Awake()
	{
		Messenger.AddListener(EGameEvents.Respanw.ToString(), OnRespawn);
	}

	private void OnDestroy()
	{
		Messenger.RemoveListener(EGameEvents.Respanw.ToString(), OnRespawn);
	}

	private void Start()
	{
		_transform = transform.parent.GetChild(2);

		
		
		_bullets = new List<Bullet>();
		_movementController = FindObjectOfType<MovementController>();

		for (int i = 0; i < transform.childCount; i++)
		{
			_bullets.Add(transform.GetChild(i).GetComponent<Bullet>());
			_bullets[i].SetActive(false);
		}
		
		Invoke(nameof(CheckForShot), 0);
	}

	private void CheckForShot()
	{
		if ((_transform.position - _movementController.GetPosition()).sqrMagnitude < _RadiusSqrDistanceToPlayer)
		{
			Shot();
			Debug.Log("SHOT");
		}
		
		Invoke(nameof(CheckForShot), _CoolDown);
	}
	
	private void Shot()
	{
		for (int i = 0; i < _bullets.Count; i++)
		{
			if (!_bullets[i].IsActive())
			{
				_bullets[i].SetActive(true);
				_bullets[i].Shot(
					_transform.position,
					(_movementController.GetPosition() - _transform.position).normalized,
					_BulletSpeed,
					_MaxBulletSqrDistance);
				return;
			}
		}
	}

	private void OnRespawn()
	{
		for (int i = 0; i < _bullets.Count; i++)
		{
			_bullets[i].SetActive(false);
		}
	}
	
	
}
