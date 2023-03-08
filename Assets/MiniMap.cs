using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MiniMap : MonoBehaviour
{
    private Transform _Player;
    public Camera MiniMapCamera;
    
    private void Start()
    {
        _Player = MiniMapCamera.transform;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(90f, 0, 0);
        MiniMapCamera.transform.position = _Player.position + new Vector3(0, 0.5f, 0);

        var rt = Resources.Load<RenderTexture>("MiniMap");
        GetComponent<Camera>().targetTexture = rt;
    }
    
    private void LateUpdate()
    {
        var newPosition = _Player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90, _Player.eulerAngles.y, 0);
    }
}
