using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(audioSource.volume < 1)
        {
            audioSource.volume = Mathf.Clamp01(audioSource.volume+(0.2f * Time.deltaTime));
        }
    }
}
