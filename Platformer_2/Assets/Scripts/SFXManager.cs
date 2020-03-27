using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    static AudioSource[] audioSources;
    static int audioIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void Play(AudioClip clip)
    {
        audioSources[audioIndex].clip = clip;
        audioSources[audioIndex].volume = 1;
        audioSources[audioIndex].Play();
        audioIndex++;
        if (audioIndex >= audioSources.Length)
        {
            audioIndex = 0;
        }
        //Debug.Log(audioIndex);
    }
    public static void Play(AudioClip clip, float volume)
    {
        audioSources[audioIndex].clip = clip;
        audioSources[audioIndex].volume = volume;
        audioSources[audioIndex].Play();
        audioIndex++;
        if (audioIndex >= audioSources.Length)
        {
            audioIndex = 0;
        }
    }
}
