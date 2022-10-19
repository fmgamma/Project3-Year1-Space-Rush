using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public enum Pickups
    {
        [InspectorName("DON'T USE")]
        NONE,
        [InspectorName("Freezer")]
        FREEZE,
        [InspectorName("Shield")]
        SHIELD,
        [InspectorName("Speed")]
        SPEED,
        [InspectorName("Teleporter")]
        TELEPORT
    }

    public bool isActive;
    public float activeTimer;
    public Pickups pickup;
    public float spawnIntermission;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
