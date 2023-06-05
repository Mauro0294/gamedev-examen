using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject roadPrefab;
    private Transform lastSpawnedRoad;
    private float roadLength;

    public void SpawnRoad()
    {
        GameObject newRoad = Instantiate(roadPrefab, lastSpawnedRoad.position + new Vector3(0f, 0f, roadLength), Quaternion.identity);
        lastSpawnedRoad = newRoad.transform;
    }

    void Start()
    {
        lastSpawnedRoad = transform;
        roadLength = roadPrefab.transform.localScale.z; // Assuming the road's length is aligned with the z-axis scale

        for (int i = 0; i < 45; i++)
        {
            SpawnRoad();
        }
    }
}
