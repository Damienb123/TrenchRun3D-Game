using UnityEngine;

// This script spawns obstacles of two types at random horizontal positions ahead of the ship
public class UniqueObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Drag your two obstacle prefabs here
    public Transform ship;               // The ship to spawn obstacles ahead of
    public float spawnDistance = 20f;    // How far ahead to spawn obstacles
    public float minX = -5f;             // Min horizontal offset
    public float maxX = 5f;              // Max horizontal offset
    public float spawnInterval = 2f;     // How often to spawn obstacles

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime; // Increment timer by the time since last frame
        // If enough time has passed, spawn a new obstacle
        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0 || ship == null) return; // Safety check

        // Pick a random obstacle
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Random horizontal offset
        float xOffset = Random.Range(minX, maxX);

        // Position in front of the ship
        Vector3 spawnPos = ship.position + new Vector3(xOffset, 0f, spawnDistance);

        // Instantiate obstacle
        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}
