using UnityEngine;

public class BulletMotorcycle : MonoBehaviour
{
    public float speed = 3f;
    public GameObject enemyBulletPrefab;
    public float fireRate = 1.5f;
    private float nextFireTime = 0f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Vector2 dir = (player.position - transform.position).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = dir * speed;
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer()
    {
        if (player == null) return;
        Vector2 dir = (player.position - transform.position).normalized;
        GameObject bullet = Instantiate(enemyBulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = dir * 5f;
        Destroy(bullet, 4f);
    }
}