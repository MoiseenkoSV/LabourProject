using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPositions;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Player : MonoBehaviour
{
    protected float _health; //��������
    protected float _maxHealth; // ������� ��������
    protected float _speed; // �������� ������������
    protected Transform _position; //������� ������

    public void SpeedUp(float speedMultyplier)
    {
        _speed = _speed* speedMultyplier; // �������� �������� ������������ �� �
    }
    public void DoSomeDamage(float damage)
    {
        _health = _health - damage; //������� �������� � ������
    }
    public void HealPlayerOn(float health)
    {
        if(_health > 0 && _health < _maxHealth)
        {
            _health = _health + health;
            if (_health > _maxHealth)
            {
                float difference = _health- _maxHealth;
                _health = _health - difference;
            }
        }
        
    }
    public void InitializePLayer(float health, float speed, Transform _resPoint, GameObject _playerPprefab)
    {
        _health=health;
        _speed=speed;
        int randomPosition = Random.Range(0,11);
        if (randomPosition == 0)
        {
            _position.position = _resPoint.position;
            Instantiate(_playerPprefab, _resPoint);
        }
        
    }
}
