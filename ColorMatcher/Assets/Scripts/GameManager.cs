using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string active_scene;
    int scene_count;
    // Start is called before the first frame update
    void Start()
    {
        active_scene = SceneManager.GetActiveScene().name;
        scene_count = SceneManager.sceneCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(active_scene == "Title" || active_scene == "GameOver")
        {

        }
    }
}
