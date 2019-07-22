using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{

	private List<IGameObject> _gameObjects;

	private void Awake()
	{
		_gameObjects = new List<IGameObject>();
		Messenger<IGameObject>.AddListener(GameEvents.ListenGameObject.ToString(), AddIGameObject);
	}

	private void Update()
	{
		for (int i = 0; i < _gameObjects.Count; i++)
		{
			_gameObjects[i].UpdateObject(Time.deltaTime);
		}
	}

	private void AddIGameObject(IGameObject iGameObject)
	{
		_gameObjects.Add(iGameObject);
	}
}
