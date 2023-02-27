using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _ќбъектЌаблюдени€;
    public float _сдвигѕоќси” = 1f;
    private Vector3 _cameraOffset;
    
    void Start()
    {
        _cameraOffset = transform.position - _ќбъектЌаблюдени€.transform.position;
    }

    public void CameraStartPosition(Vector3 starTransform)//ћетод который переносит камеру в указанную точку в начале игры.
    {
        gameObject.transform.position = starTransform;
    }
    void LateUpdate()
    {
        transform.position = _ќбъектЌаблюдени€.transform.position + _cameraOffset;
    }
}
