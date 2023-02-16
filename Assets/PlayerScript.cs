using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //���������� ����������
    protected float _health; //��������
    protected float _maxHealth; // ������� ��������
    protected float _speed; // �������� ������������
    protected float _maxSpeed; //����������� �� ��������
    protected float _armor; // ������ �� ���� �� ����� �������� �����?)
    protected Vector3 _position; //������� ������
    //����� ����������
    public Vector3 _direction; //����������� ��������;
    public float _rotationSpeed; // �������� �������� ������ ��� Y
    public Quaternion _mRotation = Quaternion.identity;
    public Rigidbody _rigidbody;


    public void SpeedUp(float speedMultyplyer)
    {
        float _lastSpeed = _speed;
        _speed = _speed * speedMultyplyer; // �������� �������� ������������ �� �
        Debug.Log("������� ��������: " + _speed);
    }

    public void SlowDown(float _speedReduce)
    {
        float _lastSpeed = _speed;
        _speed = _speed * _speedReduce;
    }
    public void DoSomeDamage(float damage)
    {
        _health = _health - damage; //������� �������� � ������
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
