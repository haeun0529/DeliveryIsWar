using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("충돌: " + other.gameObject.tag);

    if (other.CompareTag("Motorcycle"))
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(3); // 오토바이
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    if (other.CompareTag("BulletMotorcycle"))
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(5); // 탄막 오토바이
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    if (other.CompareTag("Car"))
    {
        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(3); // 승용차
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    if (other.CompareTag("Boss"))
    {
        other.GetComponent<BossController>().TakeDamage(1);
        Destroy(gameObject);
    }
}
}