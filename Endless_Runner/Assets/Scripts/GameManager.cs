using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //public bool gameover = false;
    //public GameObject player;
    void Start()
    {
        //spawn player above the stage so the player sees the stage being generated as he/she falls
        //instantiate player
        //Instantiate(player);
    }

    // Update is called once per frame
    void Update()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case (0):
                if (Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Main1");
                break;
            case (1):
                if (GameData.gameOver())
                    SceneManager.LoadScene("Ending1");
                break;
            case (2):
                if (Input.GetKeyDown(KeyCode.Space))
                    SceneManager.LoadScene("Intro1");
                break;
            default:
                break;
        }
        
    }
}
