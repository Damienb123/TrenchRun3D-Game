using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstacleType1; // Assign in Inspector
    public GameObject obstacleType2; // Assign in Inspector
    public float spawnInterval = 2f; // seconds between spawns
    public float xLimit = 4f; // trench boundaries
    public float spawnZ = 50f; // how far ahead the obstacle spawns
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 1f, spawnInterval); // Start spawning after 1 second, repeat every spawnInterval seconds
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        GameObject obstacle = Random.value > 0.5f ? obstacleType1 : obstacleType2; // Randomly choose between two obstacle types
        float xPos = Random.Range(-xLimit, xLimit); // Random x position within trench limits
        Vector3 spawnPos = new Vector3(xPos, obstacle.transform.position.y, transform.position.z + spawnZ); // Spawn position
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation); // Create the obstacle
    }
}
