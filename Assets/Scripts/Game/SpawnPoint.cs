using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject ItemPickup;


    void Start()
    {
        Instantiate(ItemPickup, transform.position, transform.rotation);
    }
}
