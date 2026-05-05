using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;
    public TextMeshProUGUI hpText;

    void Start()
    {
        currentHp = maxHp;
        UpdateHpUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Motorcycle") ||
            other.CompareTag("BulletMotorcycle") ||
            other.CompareTag("Car") ||
            other.CompareTag("EnemyBullet"))
        {
            currentHp--;
            Destroy(other.gameObject);
            UpdateHpUI();

            if (currentHp <= 0)
            {
                Debug.Log("게임 오버!");
                gameObject.SetActive(false);
            }
        }
    }

    void UpdateHpUI()
    {
        string hearts = "";
        for (int i = 0; i < currentHp; i++)
            hearts += "♥ ";
        for (int i = currentHp; i < maxHp; i++)
            hearts += "♡ ";
        hpText.text = hearts;
    }
}