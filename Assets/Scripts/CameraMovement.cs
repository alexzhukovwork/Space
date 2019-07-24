using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private PlayerController _playerController;
	
	// Use this for initialization
	void Start ()
	{
		_playerController = FindObjectOfType<PlayerController>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(transform.position.x, _playerController.transform.position.y, transform.position.z);
	}
}
