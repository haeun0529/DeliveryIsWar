using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float midBossSpawnTime = 120f;
    public float bossSpawnTime = 240f;
    public GameObject midBossPrefab;
    public GameObject bossPrefab;
    public Image bossHpFill;
    public Image midBossHpFill;

    public float currentTime = 0f;
    private bool midBossSpawned = false;
    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (!midBossSpawned && currentTime >= midBossSpawnTime)
        {
            midBossSpawned = true;
            MidBossSpawn();
        }

        if (!bossSpawned && currentTime >= bossSpawnTime)
        {
            bossSpawned = true;
            BossSpawn();
        }
    }

    void MidBossSpawn()
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
            spawner.enabled = false;

        if (midBossPrefab != null)
        {
            Vector3 spawnPos = new Vector3(0, 8f, 0);
            GameObject midBoss = Instantiate(midBossPrefab, spawnPos, Quaternion.identity);

            if (midBossHpFill != null)
            {
                midBossHpFill.transform.parent.gameObject.SetActive(true);
                MidBossController mc = midBoss.GetComponent<MidBossController>();
                if (mc != null)
                    mc.hpFill = midBossHpFill;
            }
            Debug.Log("중간 보스 등장!");
        }
    }

    void BossSpawn()
    {
        EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
        if (spawner != null)
            spawner.enabled = false;

        if (bossPrefab != null)
        {
            Vector3 spawnPos = new Vector3(0, 8f, 0);
            GameObject boss = Instantiate(bossPrefab, spawnPos, Quaternion.identity);

            if (bossHpFill != null)
            {
                bossHpFill.transform.parent.gameObject.SetActive(true);
                BossController bc = boss.GetComponent<BossController>();
                if (bc != null)
                    bc.hpFill = bossHpFill;
            }
            Debug.Log("보스 등장!");
        }
    }
}