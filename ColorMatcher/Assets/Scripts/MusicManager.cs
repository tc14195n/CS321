using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    AudioSource bg_music;
    // Start is called before the first frame update
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        if (GameObject.Find(gameObject.name) && GameObject.Find(gameObject.name) != this.gameObject && !this.gameObject.GetComponent<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        bg_music = GetComponent<AudioSource>();
        bg_music.volume = 0;
        bg_music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(bg_music.volume < 0.1f)
        {
            bg_music.volume += 0.2f * Time.deltaTime;
        }
    }

}
