using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Debug;
using Update = UnityEngine.PlayerLoop.Update;

public class SpeedUpZone : MonoBehaviour
{
    public bool isUsed = false;
    public float timer = 5f;
    private void Start()
    {
        
    }

    private void Update()
    {
        StartTimer(timer);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (isUsed == false)
        {
            Log("Бонус активирован");
            isUsed = true;
            FindObjectOfType<PlayerScript>().SpeedUp(2f);
        }
    }

    public void StartTimer(float time)
    {
        time = time - 1f * Time.deltaTime;
        
        if (timer <= 0)
        {
            isUsed = false;
            FindObjectOfType<PlayerScript>().SpeedUp(1f);
            Log("Бонус отключен");
        }
    }
}
