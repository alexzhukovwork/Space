using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Listener : MonoBehaviour
{

	[SerializeField] private string gameEvent;
	[SerializeField] private UnityEvent gameEventFunction;

	private void Awake()
	{
		Messenger.AddListener(gameEvent, InvokeEvent);
	}

	private void InvokeEvent()
	{
		gameEventFunction.Invoke();
	}
}
