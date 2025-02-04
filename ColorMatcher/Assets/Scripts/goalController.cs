﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalController : MonoBehaviour
{
    MeshRenderer mesh;
    public AudioClip pop_sound;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MeshRenderer>().material.name == mesh.material.name)
        {
            //add 1 to game_score
            Destroy(this.gameObject);
            GameData.points += 1;
            SFXManager.Play(pop_sound);
        }
    }
}
