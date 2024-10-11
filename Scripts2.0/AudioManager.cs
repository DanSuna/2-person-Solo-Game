using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    public AudioClip background;
    public AudioClip winMusic; // Add a new clip for winning
    public AudioClip loseMusic; // Add a new clip for losing
    public AudioClip damage;
    public AudioClip collect;

    private void Start()
    {
        PlayBackgroundMusic();
    }

    public void PlayBackgroundMusic()
    {
        musicSource.clip = background;
        musicSource.loop = true; // Loop background music
        musicSource.Play();
    }

    public void PlayWinMusic()
    {
        StopCurrentMusic(); // Stop current music
        musicSource.clip = winMusic; // Set win music
        musicSource.loop = false; // Don't loop win music
        musicSource.Play();
    }

    public void PlayLoseMusic()
    {
        StopCurrentMusic(); // Stop current music
        musicSource.clip = loseMusic; // Set lose music
        musicSource.loop = false; // Don't loop lose music
        musicSource.Play();
    }

    public void StopCurrentMusic()
    {
        musicSource.Stop(); // Stop current playing music
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
