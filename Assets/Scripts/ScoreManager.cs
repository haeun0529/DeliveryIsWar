using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public int bossSpawnScore = 100;
    public TextMeshProUGUI scoreText;
    private bool bossSpawned = false;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        scoreText.text = "Score: " + score;

        if (!bossSpawned && score >= bossSpawnScore)
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

    public void AddScore(int amount)
    {
        score += amount;
    }
}