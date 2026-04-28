using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    public GameObject ratPrefab;
    public float spawnRate = 1f; 
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            SpawnRat();
        }
    }

    void SpawnRat()
    {
        float randomX = Random.Range(-4f, 4f);
        Vector3 spawnPos = new Vector3(randomX, 10f, 0);
        Instantiate(ratPrefab, spawnPos, Quaternion.identity);
    }
}