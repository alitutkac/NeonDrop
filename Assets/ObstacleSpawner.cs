using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnRate = 1.1f;
    public float minX = -1.8f;
    public float maxX = 1.8f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefab == null) return;

        float randomX = Random.Range(minX, maxX);
        // Engeller ekranın üstünden (Y: 6) doğar
        Vector3 spawnPos = new Vector3(randomX, 6f, 0f);

        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}