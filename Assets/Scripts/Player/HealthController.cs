using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{

	[SerializeField] private int _HealthCount = 1;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag.Equals("Dead"))
		{
			_HealthCount--;
		}

		if (_HealthCount == 0)
		{
			Messenger.Broadcast(GameEvents.Dead.ToString());
		}
		else
		{ 
			//Messenger.Broadcast();
		}
	}

	public void AddHealth()
	{
		_HealthCount++;
	}

}
