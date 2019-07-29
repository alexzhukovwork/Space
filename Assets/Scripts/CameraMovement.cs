using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float CameraWidth = 3.5f;

    private MovementController _movementController;
    private Camera _camera;

    // Use this for initialization
    void Start ()
	{
		_movementController = FindObjectOfType<MovementController>();
        _camera = GetComponent<Camera>();
        _camera.orthographicSize = CameraWidth / _camera.aspect;
    }
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3(transform.position.x, _movementController.transform.position.y, transform.position.z);
	}
}
