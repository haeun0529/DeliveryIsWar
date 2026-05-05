using UnityEngine;
using UnityEngine.SceneManagement;

public class MidBossController : MonoBehaviour
{
    public int hp = 100;
    public float speed = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;
        Vector2 dir = (player.position - transform.position).normalized;
        transform.position += (Vector3)dir * speed * Time.deltaTime;
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