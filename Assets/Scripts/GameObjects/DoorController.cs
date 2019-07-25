using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    [SerializeField] private GameObject _Left;
    [SerializeField] private GameObject _Right;

    [SerializeField] private float _TimeClose;
    [SerializeField] private float _TimeOpen;

    private Vector3 _open = new Vector3(0, 0, 90);

    private void Awake()
    {
        Open();
    }

    private void Open()
    {
        _Left.transform.DORotate(_open * -1, 1, RotateMode.Fast);
        _Right.transform.DORotate(_open, 1, RotateMode.Fast);
        
        Invoke("Close", _TimeOpen + 1);
        

    }

    private void Close()
    {
        _Left.transform.DORotate(Vector3.zero, 1, RotateMode.Fast);
        _Right.transform.DORotate(Vector3.zero, 1, RotateMode.Fast);
        
        Invoke("Open", _TimeClose + 1);

    }
    
}
