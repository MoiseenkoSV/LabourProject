using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitTriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
            Debug.Log("����� �����");
            FindObjectOfType<GameEventContorls>().PlayerEndGame(true);
    }
}
