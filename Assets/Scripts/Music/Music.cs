using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicSource; // Reference to the Audio Source GameObject

    void Start()
    {
        musicSource.Play();
    }
}
