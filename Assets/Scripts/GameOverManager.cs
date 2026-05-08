using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {

    }

    public void Retry()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.totalScore = 0;
        SceneManager.LoadScene("Stage1");
    }
}