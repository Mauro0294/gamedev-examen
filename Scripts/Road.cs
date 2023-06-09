using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        // Get the GroundSpawner component from the GroundSpawner object
        groundSpawner = GameObject.Find("GroundSpawner").GetComponent<GroundSpawner>();
    }

    void OnTriggerExit(Collider other)
    {
        // Spawn a new road when the player exits the trigger
        groundSpawner.SpawnRoad();
        Destroy(gameObject, 2);
    }
}