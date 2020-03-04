using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text landingText;
    public AudioSource bgmusic;
    public AudioSource badEndingMusic;
    int scene_index;
    int timer = 3;
    // Start is called before the first frame update
    void Start()
    {
        scene_index = SceneManager.GetActiveScene().buildIndex;
        switch (scene_index)
        {
            case 2:
                landingText.text = (GameData.successfulLanding ? "Successful landing!" : "Failed landing!");
                if (!GameData.successfulLanding)
                {
                    bgmusic.Stop();
                    badEndingMusic.Play();
                    //stop regular soundtrack
                    //trigger "bad ending"
                }

                break;
            case 0:
                GameData.successfulLanding = true;

                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (scene_index)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
                }
                break;
            case 2:
                if (Input.GetKeyDown(KeyCode.Space) && timer < 0)
                {
                    SceneManager.LoadScene("Intro", LoadSceneMode.Single);
                } else
                {
                    timer -= (int)Time.deltaTime;
                }
                break;
            default:
                break;
        }
    }
}
