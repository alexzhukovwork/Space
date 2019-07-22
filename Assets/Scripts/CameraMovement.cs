using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private PlayerMovement _playerMovement;
	
	// Use this for initialization
	void Start ()
	{
		_playerMovement = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(transform.position.x, _playerMovement.transform.position.y, transform.position.z);
	}
}
