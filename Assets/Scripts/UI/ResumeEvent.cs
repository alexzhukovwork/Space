using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeEvent : MonoBehaviour
{

    [SerializeField] private GameObject menu;

    public void Invoke()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }
}
