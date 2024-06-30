using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }
    public void PlayRandomSFX(params string[] name)
    {
        System.Random rand = new System.Random();
        int r = rand.Next(0, name.Length);

        Sound s = Array.Find(sfxSounds, x => x.name == name[r]);

        if (s == null)
        {
            Debug.Log("SFX Not Found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.PlayOneShot(s.clip);
        }
    }


}
