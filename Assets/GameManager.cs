using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPositions;
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] public int _goalEndGame;
    public void RespawnPlayer(int positionIndex) //Метод геймменеджера, который назначает игроку точку в которой ему надо возродиться
    {
        Debug.Log(positionIndex);
        Debug.Log(SpawnPositions[positionIndex].name);
        Vector3 playerPosition = SpawnPositions[positionIndex].position;
        FindObjectOfType<PlayerScript>().StartPosition(playerPosition);
    }
}
