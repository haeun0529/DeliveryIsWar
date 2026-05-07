using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Image minDigit1;
    public Image minDigit2;
    public Image secDigit1;
    public Image secDigit2;
    public Sprite[] numberSprites;

    void Start()
    {
        minDigit1.sprite = numberSprites[0];
        minDigit2.sprite = numberSprites[0];
        secDigit1.sprite = numberSprites[0];
        secDigit2.sprite = numberSprites[0];
    }

    void Update()
    {
        if (TimerManager.Instance == null) return;

        float currentTime = TimerManager.Instance.currentTime;

        int minutes = (int)(currentTime / 60f);
        int seconds = (int)(currentTime % 60f);

        minutes = Mathf.Clamp(minutes, 0, 99);
        seconds = Mathf.Clamp(seconds, 0, 59);

        minDigit1.sprite = numberSprites[minutes / 10];
        minDigit2.sprite = numberSprites[minutes % 10];
        secDigit1.sprite = numberSprites[seconds / 10];
        secDigit2.sprite = numberSprites[seconds % 10];
    }
}