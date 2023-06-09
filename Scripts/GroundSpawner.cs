using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    Transform lastSpawnedRoad;
    float roadLength;

    public void SpawnRoad()
    {
        // Spawn a new road object at an offset position from the last spawned road
        GameObject newRoad = Instantiate(roadPrefab, lastSpawnedRoad.position + new Vector3(0f, 0f, roadLength), Quaternion.identity);

        // Update the reference to the last spawned road object
        lastSpawnedRoad = newRoad.transform;
    }

    void Start()
    {
        // Set the initial reference to the current object's transform (assuming it's the starting road)
        lastSpawnedRoad = transform;

        // Get the length of the road based on its scale along the z-axis
        roadLength = roadPrefab.transform.localScale.z;

        for (int i = 0; i < 45; i++)
        {
            SpawnRoad();
        }
    }
}