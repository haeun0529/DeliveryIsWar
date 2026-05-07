using UnityEngine;

public class Banana : MonoBehaviour
{
    public float duration = 5f;

    void Start()
    {
        Destroy(gameObject, duration);
    }
}