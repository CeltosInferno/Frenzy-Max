using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup musicMixerGroup = null;
    [SerializeField] private AudioMixerGroup soundMixerGroup = null;

    private AudioSource music;
    private readonly List<AudioSource> sound = new List<AudioSource>();
    private readonly List<AudioClip> queue = new List<AudioClip>(10);

    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioSource[] src = GetComponents<AudioSource>();
        Debug.Assert(src.Length >= 2);
        if (src.Length < 2) Application.Quit();

        music = src[0];
        music.loop = true;
        music.outputAudioMixerGroup = musicMixerGroup;

        sound.Capacity = src.Length;
        sound.AddRange(src);
        sound.Remove(src[0]);
        sound.Capacity = src.Length - 1;
        sound.ForEach(s => s.loop = false);
        sound.ForEach(s => s.outputAudioMixerGroup = soundMixerGroup);
    }

    private void Update()
    {
        if (queue.Count > 0)
        {
            AudioSource src = sound.Find(s => !s.isPlaying);
            if (src != null)
            {
                src.clip = queue[0];
                queue.RemoveAt(0);
                src.Play();
            }
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (music.clip != clip)
        {
            music.clip = clip;
            music.Play();
        }
    }

    public void PlaySound(AudioClip clip)
    {
        AudioSource src = sound.Find(s => !s.isPlaying);
        if (queue.Count > 0 || src == null)
        {
            queue.Add(clip);
        }
        else
        {
            src.clip = clip;
            src.Play();
        }
    }

}
