using UnityEngine;

public class Rat : MonoBehaviour
{
    public float speed = 6f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

        Vector2 dir = (player.position - transform.position).normalized;
        float randomAngle = Random.Range(-30f, 30f);
        dir = RotateVector(dir, randomAngle);

        GetComponent<Rigidbody2D>().linearVelocity = dir * speed;

        Destroy(gameObject, 5f);
    }

    Vector2 RotateVector(Vector2 v, float angle)
    {
        float rad = angle * Mathf.Deg2Rad;
        return new Vector2(
            v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
            v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
        );
    }
}