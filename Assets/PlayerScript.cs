using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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


    public void SpeedUp(float speedMultyplyer)
    {
        float _lastSpeed = _speed;
        _speed = _speed * speedMultyplyer; // ускоряем скорость передвижения на х
        Debug.Log("Текущая скорость: " + _speed);
    }

    public void SlowDown(float _speedReduce)
    {
        float _lastSpeed = _speed;
        _speed = _speed * _speedReduce;
    }
    public void DoSomeDamage(float damage)
    {
        _health = _health - damage; //снимаем здоровье у игрока
    }
    public void HealPlayerOn(float health)
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
    public void SetPlayerStats(float health, float speed)
    {
        _health = health;
        _maxHealth = health;
        _speed = speed;
        _maxSpeed = speed * 2.5f;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        SetPlayerStats(100, 5f);
        Debug.Log("HP: " + _health);
        Debug.Log("SPEED: " + _speed);
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    public void MovementLogic()
    {
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horInput, 0.0f, verInput);
        _rigidbody.AddForce(movement * _speed);
    }
}
