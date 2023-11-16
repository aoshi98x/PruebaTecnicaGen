using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    public AudioSource audioSource;
    [SerializeField]AudioClip gameplayMusic;

    private void Awake() 
    {       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
        audioSource=GetComponent<AudioSource>();
    }
    public void SFXnoLoop(AudioClip sound)
    {
        audioSource.loop = false;
        audioSource.PlayOneShot(sound);
    }
    public void SFXLoop(AudioClip sound)
    {
        audioSource.loop = true;
        audioSource.PlayOneShot(sound);
    }   
    public void ReplaceMusic()
    {
        audioSource.clip = gameplayMusic;
        audioSource.Play();
    }
}

