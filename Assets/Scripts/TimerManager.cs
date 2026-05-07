using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float bossSpawnTime = 120f;
    public GameObject midBossPrefab;
    public Image bossHpFill;

    public float currentTime = 0f;
    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (!bossSpawned && currentTime >= bossSpawnTime)
        {
            bossSpawned = true;
            BossSpawn();
        }
    }

    void BossSpawn()
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
            spawner.enabled = false;

        if (midBossPrefab != null)
        {
            Vector3 spawnPos = new Vector3(0, 8f, 0);
            GameObject boss = Instantiate(midBossPrefab, spawnPos, Quaternion.identity);

            if (bossHpFill != null)
            {
                bossHpFill.transform.parent.gameObject.SetActive(true);
                MidBossController midBoss = boss.GetComponent<MidBossController>();
                if (midBoss != null)
                    midBoss.hpFill = bossHpFill;
            }

            Debug.Log("중간 보스 등장!");
        }
    }
}