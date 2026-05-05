using UnityEngine;

public class MidBossController : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;   
    public float fixedY = 6f;   

    [Header("공격")]
    public GameObject bulletPrefab;
    public float fireRate = 1.5f;
    private float nextFireTime = 0f;

    [Header("HP")]
    public int hp = 100;

    private Transform player;
    private float startX;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startX = transform.position.x;

        transform.position = new Vector3(0, fixedY, 0);
    }

    void Update()
    {
        MoveLeftRight();
        ShootAtPlayer();
    }

    void MoveLeftRight()
    {
        float newX = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        transform.position = new Vector3(newX, fixedY, 0);
    }

    void ShootAtPlayer()
    {
        if (player == null) return;
        if (Time.time < nextFireTime) return;

        nextFireTime = Time.time + fireRate;

        if (bulletPrefab != null)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = dir * 6f;
            Destroy(bullet, 5f);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("중간 보스 HP: " + hp);

        if (hp <= 0)
        {
            Destroy(gameObject);
            Debug.Log("중간 보스 처치!");
        }
    }
}