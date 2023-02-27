using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerScript : MonoBehaviour
{
    //Защищенные переменные
    protected float _health; //Здоровье
    protected float _maxHealth; // Максиум здоровья
    protected float _speed; // скорость передвижения
    protected float _maxSpeed; //Ограничение по скорости
    protected float _armor; // Почему бы шару не иметь оболочку брони?)
    protected Vector3 _position; //позиция игрока
    //Общие переменные
    public Vector3 _direction; //Направление движения;
    public float _rotationSpeed; // скорость врощения вокруг оси Y
    public Quaternion _mRotation = Quaternion.identity;
    public Rigidbody _rigidbody;

    #region Методы "Скорости"
    public void ChahgeSpeedMultyplyer(float speedMultyplyer) //Метод изменения скорости передвижения игрока
    {
        _speed = _speed * speedMultyplyer; 
        Debug.Log("Текущая скорость: " + _speed);
    }

    public void ResetSpeedToDefaults(float speed) //Метод восстановления скорости по-умолчанию
    {
        _speed = speed;
    }
    #endregion
   
    #region Методы "Здоровья"
    public void DoSomeDamage(float damage) //Снимаем здоровье игрока
    {
        _health = _health - damage;
    }
    public void HealPlayerOn(float health) //Лечение игрока
    {
        if (_health > 0 && _health < _maxHealth)
        {
            _health = _health + health;
            if (_health > _maxHealth)
            {
                float difference = _health - _maxHealth;
                _health = _health - difference;
            }
        }
    }
    #endregion

    #region Инициализация игрока
    public void SetPlayerStats(float health, float speed) //Метод назначения базовых параметров игрока
    {
        _health = health;
        _maxHealth = health;
        _speed = speed;
        _maxSpeed = speed * 2.5f;
    }
    public void StartPosition(Vector3 starTransform)//Метод который переносит игрока в указанную точку в начале игры.
    {
        gameObject.transform.position = starTransform;
    }
    #endregion

    #region Физика движений
    public void MovementLogic() //Логика движения игрока
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0.0f, verInput);
        _rigidbody.AddForce(movement * _speed);
    }
    #endregion

    private void Start()
    {
        int randomPosition = Random.Range(0, 11); //Генерируем рандомное число от 0 до 11
        FindObjectOfType<GameManager>().RespawnPlayer(randomPosition); // передаем число геймменеджеру, чтобы он дал координату.
        _rigidbody = GetComponent<Rigidbody>(); //инициализируем физику
        SetPlayerStats(100, 5f); // Задаем стартовые значения параметров игрока
        Debug.Log($"Здоровье: {_health}, Скорость {_speed}");
    }
    private void FixedUpdate()
    {
        MovementLogic();
    }
}
