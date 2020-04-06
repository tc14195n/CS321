using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string active_scene;
    int scene_count;
    int scene_index;
    public Text timer_text;
    public Text gameover_message;
    public List<GameObject> balls;
    // Start is called before the first frame update
    void Start()
    {
        active_scene = SceneManager.GetActiveScene().name;
        scene_count = SceneManager.sceneCount;
        scene_index = SceneManager.GetActiveScene().buildIndex;
        
        switch (active_scene)
        {
            case "Title":
                break;
            case "Main1":
                for(int i = 0; i < balls.Count; i++)
                {
                    balls[i].transform.position = new Vector3(Random.value * 15 - 9, Random.value * 10, Random.value * 15 - 9);
                }
                GameData.countdown = 60;
                GameData.points = 0;
                break;
            case "GameOver":
                gameover_message.text = GameData.gameover_message;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (active_scene)
        {
            case "Title":
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene("Main1");
                }
                break;
            case "Main1":
                if(GameData.points == 4)
                {
                    GameData.gameover_message = "You win!";
                    SceneManager.LoadScene("GameOver");
                }
                if(GameData.countdown > 0)
                {
                    GameData.countdown -= 1f * Time.deltaTime;
                    //timer_text = GameData.countdown.ToString();
                    timer_text.text = GameData.countdown.ToString("0.00");

                } else if(GameData.countdown <= 0)
                {
                    GameData.gameover_message = "You lose!";
                    SceneManager.LoadScene("GameOver");
                }
                break;
            case "GameOver":
                if (Input.GetKey(KeyCode.Space))
                {
                    SceneManager.LoadScene("Title");
                }
                break;
            default:
                break;
        }
    }
}
