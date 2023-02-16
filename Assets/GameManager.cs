using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPositions;
    [SerializeField] GameObject _playerPrefab;

    private void Start()
    {
        int randomPosition = Random.Range(0, 11); //Генерируем рандомное число от 0 до 11
        Debug.Log(randomPosition);
        Debug.Log(SpawnPositions[randomPosition].name);
        Instantiate(_playerPrefab, SpawnPositions[randomPosition].transform);
        
    }
}
