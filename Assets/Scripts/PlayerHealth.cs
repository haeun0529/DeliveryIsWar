using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Sprite fullHeart;
    public Sprite emptyHeart;

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
            other.CompareTag("EnemyBullet") ||
            other.CompareTag("MidBossBullet") ||
            other.CompareTag("BossBullet") ||
            other.CompareTag("Banana"))
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

        if (other.CompareTag("MidBoss"))
        {
            currentHp--;
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
        heart1.sprite = currentHp >= 1 ? fullHeart : emptyHeart;
        heart2.sprite = currentHp >= 2 ? fullHeart : emptyHeart;
        heart3.sprite = currentHp >= 3 ? fullHeart : emptyHeart;
    }
}