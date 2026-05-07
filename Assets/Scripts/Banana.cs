using UnityEngine;

public class Banana : MonoBehaviour
{
    public float speed = 4f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        if (transform.position.y < -10f)
            Destroy(gameObject);
    }
}