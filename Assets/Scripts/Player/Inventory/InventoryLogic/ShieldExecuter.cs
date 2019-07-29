using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldExecuter : MonoBehaviour
{
    [SerializeField] private MovementController _movementController;

    [SerializeField] private float forceInertia = 5f;

    private void Awake()
    {
        Messenger<GameObject>.AddListener(EGameEvents.ShieldExecute.ToString(), ShieldExecute);
    }

    private void OnDestroy()
    {
        Messenger<GameObject>.RemoveListener(EGameEvents.ShieldExecute.ToString(), ShieldExecute);
    }

    private void ShieldExecute(GameObject gameObject)
    {
        gameObject.SetActive(false);
        
        _movementController.AddForceFromPoint(gameObject.transform.position, forceInertia);
        
        
    }
}
