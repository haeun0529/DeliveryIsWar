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

        if (transform.position.y > 8f || transform.position.y < -8f ||
            transform.position.x > 6f || transform.position.x < -6f)
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
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("BulletMotorcycle"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(5);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if (other.CompareTag("Car"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(2);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}