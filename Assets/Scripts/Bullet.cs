using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 1;

    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > 7f || transform.position.y < -7f ||
            transform.position.x > 5f || transform.position.x < -5f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Motorcycle"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(3);
            if (ItemSpawner.Instance != null)
                ItemSpawner.Instance.TrySpawnItem(other.transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("BulletMotorcycle"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(5);
            if (ItemSpawner.Instance != null)
                ItemSpawner.Instance.TrySpawnItem(other.transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Car"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(2);
            if (ItemSpawner.Instance != null)
                ItemSpawner.Instance.TrySpawnItem(other.transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("MidBoss"))
        {
            MidBossController midBoss = other.GetComponent<MidBossController>();
            if (midBoss != null)
                midBoss.TakeDamage((int)damage);
            Destroy(gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            BossController boss = other.GetComponent<BossController>();
            if (boss != null)
                boss.TakeDamage((int)damage);
            Destroy(gameObject);
        }
    }
}