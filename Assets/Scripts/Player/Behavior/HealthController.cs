using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

	[SerializeField] private int _HealthCount = 1;

	private void Awake()
	{
		Messenger<int>.AddListener(EGameEvents.EquipShield.ToString(), AddHealth);
	}

	private void OnDestroy()
	{
		Messenger<int>.RemoveListener(EGameEvents.EquipShield.ToString(), AddHealth);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (!other.gameObject.tag.Equals("Dead"))
			return;

		_HealthCount--;
		
		if (_HealthCount <= 0)
		{
			Messenger.Broadcast(EGameEvents.Dead.ToString());
		}
		else
		{ 
			Messenger<GameObject>.Broadcast(EGameEvents.ShieldExecute.ToString(), other.gameObject);
		}
	}

	public void AddHealth(int count)
	{
		_HealthCount += count;
	}

}
