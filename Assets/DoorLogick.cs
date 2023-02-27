using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogick : MonoBehaviour
{
    [SerializeField] Collider _exitCollider;
    private void Update()
    {
        if (FindObjectOfType<GameManager>()._hasKey)
        {
            gameObject.SetActive(false);
            Debug.Log("Дверь открыта! Беги!");
        }
    }
}
