using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public float bossSpawnTime = 60f;
    public TextMeshProUGUI timerText;

    private float currentTime = 0f;
    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        int minutes = (int)(currentTime / 60f);
        int seconds = (int)(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (!bossSpawned && currentTime >= bossSpawnTime)
        {
            bossSpawned = true;
            BossSpawn();
        }
    }

    void BossSpawn()
    {
        FindObjectOfType<RatSpawner>().enabled = false;
        Debug.Log("보스 등장!");
    }
}