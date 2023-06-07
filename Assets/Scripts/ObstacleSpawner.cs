using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject player;
    public PlayerManager playerManager;
    public float spawnDistance = 30f;
    public float destroyDistance = 40f; // Distance at which obstacles are destroyed
    public float spawnInterval = 0.75f;

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
            // Makes the obstacles spawn faster as the player's speed increases
            if (playerManager.speed > 9f && playerManager.speed <= 15f)
            {
                spawnDistance = 40f;
                destroyDistance = 45f;
                spawnInterval = 0.5f;
            }
            else if (playerManager.speed > 15f && playerManager.speed <= 50f)
            {
                spawnDistance = 50f;
                destroyDistance = 55f;
                spawnInterval = 0.3f;
            } else if (playerManager.speed > 50f) {
                spawnDistance = 60f;
                destroyDistance = 65f;
                spawnInterval = 0.2f;
            }

            timer += Time.deltaTime;


            if (timer >= spawnInterval)
            {
                Vector3 spawnPosition = player.transform.position + player.transform.forward * spawnDistance;
                spawnPosition.y = 1f; // Set the y-coordinate to 1
                spawnPosition.x = Random.Range(-5.5f, 3f); // Randomize the z-coordinate
                // rotate the obstacle to 90 degrees


                Quaternion spawnRotation = Quaternion.Euler(0f, 90f, 0f);

                GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, spawnRotation);
                spawnedObstacles.Add(obstacle);

                timer = 0f; // Reset the timer
            }
        }

        CheckDestroyDistance();
    }

    // Destroys obstacles that are too far away from the player
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
