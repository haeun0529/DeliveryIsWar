using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public static ItemSpawner Instance;
    public GameObject attackItemPrefab;
    public GameObject speedItemPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void TrySpawnItem(Vector3 position)
    {
        float rand = Random.Range(0f, 1f);
        if (rand > 0.05f) return;

        float rand2 = Random.Range(0f, 1f);
        if (rand2 < 0.5f)
            Instantiate(attackItemPrefab, position, Quaternion.identity);
        else
            Instantiate(speedItemPrefab, position, Quaternion.identity);
    }
}