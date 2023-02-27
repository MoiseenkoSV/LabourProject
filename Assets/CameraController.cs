using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _����������������;
    public float _����������� = 1f;
    private Vector3 _cameraOffset;
    
    void Start()
    {
        _cameraOffset = transform.position - _����������������.transform.position;
    }

    public void CameraStartPosition(Vector3 starTransform)//����� ������� ��������� ������ � ��������� ����� � ������ ����.
    {
        gameObject.transform.position = starTransform;
    }
    void LateUpdate()
    {
        transform.position = _����������������.transform.position + _cameraOffset;
    }
}
