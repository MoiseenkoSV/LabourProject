using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Debug;
using Update = UnityEngine.PlayerLoop.Update;

public class SpeedUpZone : MonoBehaviour
{
    [Header("Изменяемые параметры")]
    [SerializeField] private float time; //Тут задается время через инспектор
    [SerializeField] private Text timerText; //добавляется текстовое поле, в котором отображается таймер
    
    private bool _isUsed = false; // бул который указывает на состояние бонуса, активен или нет
    private float _timeLeft;
    
    private void Start()
    {
        _timeLeft = time;
        timerText.enabled = false;
    }

    private void Update()
    {
        if (_isUsed)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimerUI();
            }
            else
            {
                _timeLeft = time;
                FindObjectOfType<PlayerScript>().ResetSpeedToDefaults(5f);
                _isUsed = false;
                timerText.enabled = false;
                Log("Бонус отключен");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isUsed == false)
        {
            Log("Бонус активирован");
            _isUsed = true;
            FindObjectOfType<PlayerScript>().ChahgeSpeedMultyplyer(2f);
        }
    }
    
    private void UpdateTimerUI()
    {
        timerText.enabled = true;
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("Ускорение: {0:00} : {1:00}", minutes, seconds);
    }
}
