using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

	private Movement _movement;
	
	// Use this for initialization
	void Start ()
	{
		_movement = FindObjectOfType<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, _movement.transform.position.y, transform.position.z);
	}
}
