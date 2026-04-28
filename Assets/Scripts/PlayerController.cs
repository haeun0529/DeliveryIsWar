using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("이동")]
    public float speed = 5f;

    [Header("발사")]
    public GameObject bulletPrefab;    
    public Transform firePoint;     
    public float fireRate = 0.2f;      

    private float nextFireTime = 0f;

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

        float clampX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f);
        float clampY = Mathf.Clamp(transform.position.y, -5f, 5f);
        transform.position = new Vector2(clampX, clampY);
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}