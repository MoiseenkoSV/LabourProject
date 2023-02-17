using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogick : MonoBehaviour
{
    private void Update()
    {
        if (FindObjectOfType<GameManager>()._hasKey)
        {
            gameObject.SetActive(false);
            Debug.Log("Дверь открыта! Беги!");
        }
    }
}
