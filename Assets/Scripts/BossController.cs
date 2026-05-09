using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed = 2f;
    public float moveRange = 3f;
    public float fixedY = 6f;

    [Header("유도탄")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    [Header("바나나껍질")]
    public GameObject bananaPrefab;
    public float bananaSpawnRate = 3f;
    private float nextBananaTime = 0f;
    private float[] laneX = { -4.3f, -1.75f, 1f, 3.7f };

    [Header("HP")]
    public int hp = 300;
    public int maxHp = 300;
    public Image hpFill;

    [Header("다음 씬")]
    public string nextScene = "Stage2";

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        transform.position = new Vector3(0, fixedY, 0);
    }

    void Update()
    {
        MoveLeftRight();
        ShootAtPlayer();
        SpawnBanana();
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
            Destroy(bullet, 4f);
        }
    }

    void SpawnBanana()
    {
        if (Time.time < nextBananaTime) return;
        nextBananaTime = Time.time + bananaSpawnRate;

        if (bananaPrefab != null)
        {
            int laneIndex = Random.Range(0, laneX.Length);
            float randomY = Random.Range(-5f, 3f);
            Vector3 spawnPos = new Vector3(laneX[laneIndex], 10f, 0);
            Instantiate(bananaPrefab, spawnPos, Quaternion.identity);
        }
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hpFill != null)
            hpFill.fillAmount = (float)hp / maxHp;

        Debug.Log("보스 HP: " + hp);

        if (hp <= 0)
        {
            if (hpFill != null)
                hpFill.transform.parent.gameObject.SetActive(false);

            Destroy(gameObject);
            SceneManager.LoadScene(nextScene);
        }
    }
}