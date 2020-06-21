using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip backgroundClip;
    public AudioClip shotClip;
    public AudioClip quackClip;
    public AudioClip youLoseClip;
    public AudioClip youWinClip;
    public static AudioSource backgroundAudioSource;
    public static AudioSource shotAudioSource;
    public static AudioSource quackAudioSource;
    public static AudioSource youLoseAudioSource;
    public static AudioSource youWinAudioSource;

    AudioSource AddAudio(AudioClip clip, bool playOnAwake, bool loop, float volume)
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.playOnAwake = playOnAwake;
        audioSource.loop = loop;
        audioSource.volume = volume;
        return audioSource;
    }

    // Start is called before the first frame update
    void Awake()
    {
        backgroundAudioSource = AddAudio(backgroundClip, true, true, 1.0f);
        shotAudioSource = AddAudio(shotClip, false, false, 1.0f);
        quackAudioSource = AddAudio(quackClip, false, false, 1.0f);
        youLoseAudioSource = AddAudio(youLoseClip, false, false, 1.0f);
        youWinAudioSource = AddAudio(youWinClip, false, false, 1.0f);
    }

   


    
}
