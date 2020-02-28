using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text landingText;
    int scene_index;
    // Start is called before the first frame update
    void Start()
    {
        scene_index = SceneManager.GetActiveScene().buildIndex;
        switch (scene_index)
        {
            case 2:
                landingText.text = (GameData.successfulLanding ? "Successful landing!" : "Failed landing!");
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
