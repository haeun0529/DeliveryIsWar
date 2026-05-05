using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float bossSpawnTime = 120f;
    public TextMeshProUGUI timerText;
    public GameObject midBossPrefab;
    public Slider bossHpBar;

    private float currentTime = 0f;
    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (bossSpawned) return;

        currentTime += Time.deltaTime;

        int minutes = (int)(currentTime / 60f);
        int seconds = (int)(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (currentTime >= bossSpawnTime)
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

            if (bossHpBar != null)
            {
                bossHpBar.gameObject.SetActive(true);
                MidBossController midBoss = boss.GetComponent<MidBossController>();
                if (midBoss != null)
                    midBoss.hpBar = bossHpBar;
            }

            Debug.Log("중간 보스 등장!");
        }
    }
}