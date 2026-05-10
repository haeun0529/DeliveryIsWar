using UnityEngine;

public class BGMController : MonoBehaviour
{
    public AudioSource audioSource;
    public float delay = 4f;

    void Start()
    {
        audioSource.PlayDelayed(delay);
    }
}