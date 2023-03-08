using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;


public sealed class RadarScript : MonoBehaviour
{
   /* private Transform _playerPosition;
    private readonly float _mapScale = 2;
    public static List<RadarObject> radarObjects = new List<RadarObject>();

    private void Start()
    {
        _playerPosition = Camera.main.transform;
    }

    public static void RegisterRadarObject(GameObject o, Image i)
    {
        Image image = Instantiate(i);
        radarObjects.Add(new RadarObject(GameObject o, Image i));
        
    }*/
} 

public sealed class RadarObject
{
    public Image Icon;
    private GameObject Owner;
}
