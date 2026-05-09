using UnityEngine;

public class Item_AttackSpeed : MonoBehaviour
{
    public float fireRateBonus = 0.2f;
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
            other.GetComponent<PlayerController>().IncreaseFireRate(fireRateBonus);
            Debug.Log("공격속도 +" + fireRateBonus);
            Destroy(gameObject);
        }
    }
}