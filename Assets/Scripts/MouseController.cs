using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	private Movement _movement;
	// Use this for initialization
	void Start ()
	{
		_movement = FindObjectOfType<Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(p);
			_movement.AddForceFromPoint(p);
		}
	}
}
