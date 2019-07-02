using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcaster : MonoBehaviour
{
	[SerializeField] private string gameEvent;

	public void SendGameEvent()
	{
		Messenger.Broadcast(gameEvent, MessengerMode.DONT_REQUIRE_LISTENER);
	}
}
