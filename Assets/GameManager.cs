using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform[] SpawnPositions;
    [SerializeField] Transform[] CameraSpawns;
    [SerializeField] GameObject _playerPrefab;
    [SerializeField] public bool _hasKey;
    public void RespawnPlayer(int positionIndex) //Метод геймменеджера, который назначает игроку точку в которой ему надо возродиться
    {
        Debug.Log(positionIndex);
        Debug.Log(SpawnPositions[positionIndex].name);
        Vector3 playerPosition = SpawnPositions[positionIndex].position;
        Vector3 cameraPosition = CameraSpawns[positionIndex].position;
        FindObjectOfType<PlayerScript>().StartPosition(playerPosition);
        FindObjectOfType<CameraController>().CameraStartPosition(cameraPosition);
    }

    public void PlayerFoundKey(bool result)
    {
        _hasKey = result;
        Debug.Log("Игрок нашел ключ? " +_hasKey);
    }


}
