using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _player;
    private Vector3 _cameraOffset;
    void Start()
    {
        _cameraOffset = transform.position - _player.transform.position;
    }


    void LateUpdate()
    {
        transform.position = _player.transform.position + _cameraOffset;
    }
}
