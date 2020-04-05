using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audio = GetComponent<AudioSource>();
        audio.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(audio.volume < 1)
        {
            audio.volume += 0.2f * Time.deltaTime;
        }
    }
}
