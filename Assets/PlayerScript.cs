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
    protected float _health; //«доровье
    protected float _maxHealth; // ћаксиум здоровь€
    protected float _speed; // скорость передвижени€
    protected Transform _position; //позици€ игрока

    public void SpeedUp(float speedMultyplier)
    {
        _speed = _speed* speedMultyplier; // ускор€ем скорость передвижени€ на х
    }
    public void DoSomeDamage(float damage)
    {
        _health = _health - damage; //снимаем здоровье у игрока
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
