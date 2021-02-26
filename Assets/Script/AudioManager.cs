using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = s.audioMixerGroup;
        }
    } 

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name.ToLower() == name.ToLower());
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name.ToLower() == name.ToLower());
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    private void Start()
    {
        Play("Menu theme");
    }

    public void nextMusic()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                this.StopPlaying("Menu theme");
                this.Play("Level 1 theme");
                break;
            case 1:
                this.StopPlaying("Level 1 theme");
                this.Play("Level 2 theme");
                break;
            case 2:
                this.StopPlaying("Level 2 theme");
                this.Play("Level 3 theme");
                break;
            case 3:
                this.StopPlaying("Level 3 theme");
                this.Play("Credit theme");
                break;
        }
    }

    public void MuteGroup(AudioMixerGroup group)
    {
        group.audioMixer.SetFloat(group.name + "Volume", -80f);
        if (group.name.ToLower() == "music")
        {
            Singleton.Instance.IsMusicMute = true;
        }
        if(group.name.ToLower() == "voice")
        {
            Singleton.Instance.IsVoiceMute = true;
        }
    }

    public void DemuteGroup(AudioMixerGroup group)
    {
        group.audioMixer.SetFloat(group.name + "Volume", 0f);
        if (group.name.ToLower() == "music")
        {
            Singleton.Instance.IsMusicMute = false;
        }
        if (group.name.ToLower() == "voice")
        {
            Singleton.Instance.IsVoiceMute = false;
        }
    }
}
