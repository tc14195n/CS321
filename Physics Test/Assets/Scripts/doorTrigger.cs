﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorTrigger : MonoBehaviour
{
    public string levelName;
    public AudioClip tada;
    public SoundEffectManager soundEffectManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(levelName);
        soundEffectManager.Play(tada);
    }
}
