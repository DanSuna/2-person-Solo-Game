using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;


    public AudioClip menuMusic;  // Add menu music


    private void Start()
    {
        PlayMenuMusic(); // Play menu music on start
    }

    public void PlayMenuMusic()
    {
        musicSource.clip = menuMusic;
        musicSource.loop = true; // Loop menu music
        musicSource.Play();
    }


    private void StopCurrentMusic()
    {
        musicSource.Stop(); // Stop current playing music
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
