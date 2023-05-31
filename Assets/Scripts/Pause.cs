using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    private AudioSource[] allAudioSources;
    private Animator[] allAnimators;

    private void Start()
    {
        allAudioSources = FindObjectsOfType<AudioSource>();
        allAnimators = FindObjectsOfType<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f; 

        foreach (var audioSource in allAudioSources)
        {
            audioSource.Pause();
        }

        foreach (var animator in allAnimators)
        {
            animator.speed = 0f;
        }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f; 

        foreach (var audioSource in allAudioSources)
        {
            audioSource.UnPause();
        }

        foreach (var animator in allAnimators)
        {
            animator.speed = 1f;
        }
    }
}
