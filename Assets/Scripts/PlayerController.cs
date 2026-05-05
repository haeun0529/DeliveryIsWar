using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동")]
    public float speed = 5f;

    [Header("발사")]
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    public int damage = 1;

    private float nextFireTime = 0f;
    private Vector3 fireOffset = new Vector3(0, 0.5f, 0);

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(h, v) * speed * Time.deltaTime);

        float clampX = Mathf.Clamp(transform.position.x, -4.5f, 4.5f);
        float clampY = Mathf.Clamp(transform.position.y, -7f, 7f);
        transform.position = new Vector2(clampX, clampY);
    }

    void Shoot()
    {
        if (bulletPrefab == null) return;

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Vector3 spawnPos = transform.position + fireOffset;
            GameObject newBullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

            Bullet bulletScript = newBullet.GetComponent<Bullet>();
            if (bulletScript != null)
                bulletScript.damage = damage;
        }
    }

    public void IncreaseDamage(int amount)
    {
        damage += amount;
    }

    public void IncreaseFireRate(float amount)
    {
        fireRate = Mathf.Max(0.05f, fireRate - amount);
    }
}