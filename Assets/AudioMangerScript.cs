using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public enum AudioType
{

    BACKGROUND,
    BALL,
    BUTTON,
    WALLHIT
}
public class AudioMangerScript : MonoBehaviour
{
    
    public static AudioMangerScript Instance { get; private set; }


    [SerializeField] private List<Sound> sounds = new List<Sound>();

    [System.Serializable]
    public class Sound
    {
        public AudioType audioType;
        public AudioClip audioClip;
    }

    public AudioSource audioSource{ get; set; }
    public AudioSource musicSource { get; set; }


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource attached!");
        }
    }


    public void BackgroundMusic(AudioType audioType)
    {
        Sound sound = sounds.Find(x => x.audioType == audioType);
        if (sound != null && sound.audioClip != null && musicSource != null)
        {
            musicSource.clip = sound.audioClip;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background clip not found");
        }
    }
    

    public void PlayOneShot(AudioType type)
    {
        Sound sound = sounds.Find(s => s.audioType == type);

        if (sound != null && sound.audioClip != null)
        {
            audioSource.PlayOneShot(sound.audioClip);
        }
        else
        {
            Debug.LogWarning("AudioClip not found");
        }
    }
    
}