using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fallZoneController : MonoBehaviour
{
    public AudioClip fallClip;
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
        if(collision.gameObject.tag == "Player")
        {
            SFXManager.Play(fallClip,0.01f);
            SceneManager.LoadScene("GameOver");
        }
    }
}
