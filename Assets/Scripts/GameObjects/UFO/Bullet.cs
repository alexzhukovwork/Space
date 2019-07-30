using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Vector3 _defaultPosition;

	private Transform _transform;
	private GameObject _gameObject;

	private void Start()
	{
		_transform = transform;
		_defaultPosition = _transform.localPosition;
		_gameObject = gameObject;
	}

	public bool IsActive()
	{
		return _gameObject.activeSelf;
	}

	public void SetActive(bool isActive)
	{
		_gameObject.SetActive(isActive);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (!other.gameObject.tag.Equals("Player"))
		{
			other.gameObject.SetActive(false);
		}

		SetActive(false);
	}

	public void Shot(Vector3 from, Vector3 dir, float speed, float sqrMaxDistance)
	{
		_transform.position = from + _defaultPosition;
		
		StartCoroutine(MoveToDir(dir, speed, sqrMaxDistance));
	}

	private IEnumerator MoveToDir(Vector3 dir, float speed, float sqrMaxDistance)
	{
		Vector3 start = _transform.position;
		WaitForSeconds waitForSeconds = new WaitForSeconds(0.008f);
		while (_gameObject.activeSelf)
		{
			_transform.position = speed * Time.deltaTime * dir + _transform.position;
			
			if ((_transform.position - start).sqrMagnitude > sqrMaxDistance)
				SetActive(false);

			yield return waitForSeconds;
		}
	}

}
