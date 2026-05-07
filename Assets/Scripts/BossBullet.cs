using UnityEngine;

public class BossBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}