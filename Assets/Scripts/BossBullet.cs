using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 5f;
    public float trackingTime = 2f; 
    private Transform player;
    private float spawnTime;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        spawnTime = Time.time;
        Destroy(gameObject, 6f);
    }

    void Update()
    {
        if (player == null)
        {
            transform.position += transform.up * speed * Time.deltaTime;
            return;
        }

        if (Time.time - spawnTime <= trackingTime)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.up = Vector2.Lerp(transform.up, dir, Time.deltaTime * 3f);
        }

        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}