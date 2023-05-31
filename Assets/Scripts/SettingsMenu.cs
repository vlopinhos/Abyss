using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource.Play();
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
