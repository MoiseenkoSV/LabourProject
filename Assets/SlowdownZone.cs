using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowdownZone : MonoBehaviour
{
    [Header("Изменяемые параметры")]
    [SerializeField] private float time; //Тут задается время через инспектор
    [SerializeField] private Text timerText; //добавляется текстовое поле, в котором отображается таймер

    [Header("Тестовое поле")] 
    [SerializeField] private GameObject playerPrefab;
    
    private bool _isUsed = false; // бул который указывает на состояние бонуса, активен или нет
    private float _timeLeft;
    
    private void Start()
    {
        _timeLeft = time;
        timerText.enabled = playerPrefab.GetComponentInChildren<Camera>(GetComponentInChildren<Canvas>(GetComponentInChildren<Text>()));
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
                Debug.Log("Дебаф отключен");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (_isUsed == false)
        {
            Debug.Log("Дебаф активирован");
            _isUsed = true;
            FindObjectOfType<PlayerScript>().ChahgeSpeedMultyplyer(0.2f);
        }
    }
    
    private void UpdateTimerUI()
    {
        timerText.enabled = true;
        if (_timeLeft < 0)
            _timeLeft = 0;
 
        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("Замедление: {0:00} : {1:00}", minutes, seconds);
    }
}
