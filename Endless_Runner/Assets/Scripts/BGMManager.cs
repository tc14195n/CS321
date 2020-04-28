using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BGMManager : MonoBehaviour
{
    AudioSource[] sources;
    public AudioClip bgm1;
    //int current_source;
    // Start is called before the first frame update
    void Start()
    {
        //current_source = 0;
        sources = GetComponents<AudioSource>();
        if(SceneManager.GetActiveScene().buildIndex != 1)
            DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (!sources[0].isPlaying)
        {
            sources[0].clip = bgm1;
            sources[0].volume = 0.5f;
            sources[0].Play();

        }
    }
}
