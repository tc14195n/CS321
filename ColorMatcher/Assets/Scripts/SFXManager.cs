using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    static AudioSource[] audio_sources;
    int max_len;

    static int current_channel;
    // Start is called before the first frame update
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name) && GameObject.Find(gameObject.name) != this.gameObject )
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audio_sources = GetComponents<AudioSource>();
        max_len = audio_sources.Length;
        current_channel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(current_channel >= max_len)
        {
            current_channel = 0;
        }
    }
    public static void Play(AudioClip clip)
    {
        audio_sources[current_channel].clip = clip;
        audio_sources[current_channel].Play();
        current_channel += 1;
    }
}
