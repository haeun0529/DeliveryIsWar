using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("프리팹")]
    public GameObject motorcyclePrefab;
    public GameObject bulletMotorcyclePrefab;
    public GameObject carPrefab;

    [Header("스폰 설정")]
    public float spawnRate = 1.5f;
    private float nextSpawnTime = 0f;

    // 차선 X좌표
    private float[] laneX = { -4f, -1.5f, 1.5f, 4.0f };

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        float rand = Random.Range(0f, 1f);

        if (rand < 0.5f)
        {
            float rand2 = Random.Range(0f, 1f);
            float randomX = Random.Range(-4f, 4f);
            Vector3 spawnPos = new Vector3(randomX, 10f, 0);

            if (rand2 < 0.4f)
            {
                // 40% 탄막투척 오토바이
                Instantiate(bulletMotorcyclePrefab, spawnPos, Quaternion.identity);
            }
            else
            {
                // 60% 일반 오토바이
                Instantiate(motorcyclePrefab, spawnPos, Quaternion.identity);
            }
        }
        else
        {
            // 50% 승용차 - 랜덤 차선
            int laneIndex = Random.Range(0, laneX.Length);
            Vector3 spawnPos = new Vector3(laneX[laneIndex], 10f, 0);
            Instantiate(carPrefab, spawnPos, Quaternion.identity);
        }
    }
}