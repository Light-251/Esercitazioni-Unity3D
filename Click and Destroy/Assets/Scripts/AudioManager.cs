using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource mainMusicSource;
    //public AudioSource[] effectsSource;
    [SerializeField]
    private float effectsVolume = 1f;
    [SerializeField]
    private float mainMusicVolume = 0.7f;
    public Sound[] sounds;
    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    private void Update()
    {
        mainMusicSource.volume = mainMusicVolume;
        //effectsSource.volume = effectsVolume;
    }
    public void MainMusicVolume(float volume)
    {
        mainMusicVolume = volume;
    }
    public void EffectsVolume(float volume)
    {
        //effectsVolume = volume;
        for(int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.volume = volume;
        }
    }
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }   
}