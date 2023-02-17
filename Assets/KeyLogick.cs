using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyLogick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("Нашел");
            FindObjectOfType<GameManager>().PlayerFoundKey(true);
            gameObject.SetActive(false);
    }
}
