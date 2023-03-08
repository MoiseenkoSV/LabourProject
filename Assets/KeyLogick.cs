using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyLogick : MonoBehaviour
{
    delegate void ChangeKeyStatus(bool booleen);

    private ChangeKeyStatus _changeKeyStatus;
    private void Start()
    {
        _changeKeyStatus = FindObjectOfType<GameManager>().PlayerFoundKey;
    }

    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Нашел");
            _changeKeyStatus(true);
            gameObject.SetActive(false);
    }
}
