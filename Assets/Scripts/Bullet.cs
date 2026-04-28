using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private float destroyTime = 3f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}