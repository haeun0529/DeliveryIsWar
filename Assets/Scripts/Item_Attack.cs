using UnityEngine;

public class Item_Attack : MonoBehaviour
{
    public float damageBonus = 0.5f;
    public float moveSpeed = 2f;

    void Start()
    {
        Destroy(gameObject, 8f);
    }

    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;

        if (transform.position.y < -10f)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().IncreaseDamage(damageBonus);
            Debug.Log("공격력 +" + damageBonus);
            Destroy(gameObject);
        }
    }
}