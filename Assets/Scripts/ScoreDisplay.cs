using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Image digit1;
    public Image digit2;
    public Image digit3;
    public Image digit4;
    public Image digit5;

    public Sprite[] numberSprites;

    void Start()
    {
        digit1.sprite = numberSprites[0];
        digit2.sprite = numberSprites[0];
        digit3.sprite = numberSprites[0];
        digit4.sprite = numberSprites[0];
        digit5.sprite = numberSprites[0];
    }

    void Update()
    {
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (ScoreManager.Instance == null) return;

        int score = ScoreManager.Instance.score;
        score = Mathf.Clamp(score, 0, 99999);

        int d1 = score / 10000;
        int d2 = (score % 10000) / 1000;
        int d3 = (score % 1000) / 100;
        int d4 = (score % 100) / 10;
        int d5 = score % 10;

        digit1.sprite = numberSprites[d1];
        digit2.sprite = numberSprites[d2];
        digit3.sprite = numberSprites[d3];
        digit4.sprite = numberSprites[d4];
        digit5.sprite = numberSprites[d5];
    }
}