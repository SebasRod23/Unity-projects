using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioClip sound1, sound2, sound3, sound4;
    static AudioSource audioSrc;

    public static SoundManager instance;

    void Awake() {
        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }  

        DontDestroyOnLoad(gameObject);  

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        // TODO: Rename sounds and order them
        sound1 = Resources.Load<AudioClip>("Sounds/MainTheme");
        sound2 = Resources.Load<AudioClip>("Sounds/fruitCollected");
        sound3 = Resources.Load<AudioClip>("Sounds/checkpoint");
        sound4 = Resources.Load<AudioClip>("Sounds/shot");

        audioSrc = GetComponent<AudioSource>();
    }

    // FindObjectOfType<SoundManager>().Play("SongName");
    // SoundManager.PlaySound("SongName");
    // FindObjectOfType<SoundManager>().StopPlaying("sound string name");

    public void Play(string name) {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        
        if (s == null) {
            Debug.Log("Not found: " + name);
            return;
        }
        
        s.source.Play();
    }

    public void StopPlaying (string sound) {
        Sound s = Array.Find(sounds, item => item.name == sound);
        
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void StopAllSongs () {
        for (int i=0; i<sounds.Length; i++) {
            sounds[i].source.Stop();
        }
    }
    
    public static void PlaySound (string clip) {
        switch (clip) {
            case "Music":
                audioSrc.PlayOneShot(sound1, 0.5f);
                break;
            case "Collected":
                audioSrc.PlayOneShot(sound2, 0.25f);
                break;
            case "Reached":
                audioSrc.PlayOneShot(sound3, 0.9f);
                break;
            case "Shot":
                audioSrc.PlayOneShot(sound4, 0.75f);
                break;
        }
    }
}
