using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 5f;

    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.down * speed;
        Destroy(gameObject, 8f);
    }
}