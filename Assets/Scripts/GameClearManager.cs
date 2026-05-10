using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClearManager : MonoBehaviour
{
    public Image digit1;
    public Image digit2;
    public Image digit3;
    public Image digit4;
    public Image digit5;
    public Sprite[] numberSprites;

    void Start()
    {
        int score = 0;
        if (GameManager.Instance != null)
            score = GameManager.Instance.totalScore;

        score = Mathf.Clamp(score, 0, 99999);

        digit1.sprite = numberSprites[score / 10000];
        digit2.sprite = numberSprites[(score % 10000) / 1000];
        digit3.sprite = numberSprites[(score % 1000) / 100];
        digit4.sprite = numberSprites[(score % 100) / 10];
        digit5.sprite = numberSprites[score % 10];
    }

    public void GoMainMenu()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.totalScore = 0;
        SceneManager.LoadScene("MainMenu");
    }
}