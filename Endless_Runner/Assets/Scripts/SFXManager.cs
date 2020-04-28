using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    static AudioSource[] sources;
    static int current_source;
    // Start is called before the first frame update
    void Start()
    {
        current_source = 0;
        sources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playClip(AudioClip clip, float volume)
    {
        sources[current_source].clip = clip;
        sources[current_source].Play();
        sources[current_source].volume = volume;
        Debug.Log("sources.length: " + sources.Length);
        Debug.Log("current_source: " + current_source);
        current_source += 1;
        if (current_source >= sources.Length)
        {
            current_source = 0;
            Debug.Log("Resetting current_source");
        }
    }
}
