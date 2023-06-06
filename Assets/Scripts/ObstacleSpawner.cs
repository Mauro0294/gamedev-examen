using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;
    public float spawnDistance = 40f;
    public float destroyDistance = 100f; // Distance at which obstacles are destroyed
    public float spawnInterval = 1.5f;

    private float timer = 0f;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            timer += Time.deltaTime;

            if (timer >= spawnInterval)
            {
                Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
                spawnPosition.y = 1f; // Set the y-coordinate to 1
                spawnPosition.x = Random.Range(-5f, 3f); // Randomize the z-coordinate
                // rotate the obstacle to 90 degrees


                Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);

                GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, spawnRotation);
                spawnedObstacles.Add(obstacle);

                timer = 0f; // Reset the timer
            }
        }

        CheckDestroyDistance();
    }

    private void CheckDestroyDistance()
    {
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            GameObject obstacle = spawnedObstacles[i];

            if (obstacle != null)
            {
                float distance = Mathf.Abs(obstacle.transform.position.z - player.transform.position.z);
                if (distance >= destroyDistance)
                {
                    Destroy(obstacle);
                    spawnedObstacles.RemoveAt(i);
                }
            }
            else
            {
                spawnedObstacles.RemoveAt(i);
            }
        }
    }
}
