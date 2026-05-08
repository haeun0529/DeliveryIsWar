using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        if (GameManager.Instance != null)
            scoreText.text = "SCORE: " + GameManager.Instance.totalScore;
    }

    public void Retry()
    {
        GameManager.Instance.totalScore = 0;
        SceneManager.LoadScene("Stage1");
    }
}