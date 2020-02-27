using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public Text score;
	public Text timeDisplay;
	public Text scoreHI;
	public Text roundNum;
	float timer;
	public int targetsHit;
	int clicks;

    // Start is called before the first frame update
    void Start()
    {
    	if(SceneManager.GetActiveScene().buildIndex == 1){
    		GameData.score = 0;
    	}
        timer = 10;
        targetsHit = 0;
        clicks = 0;
    }

    // Update is called once per frame
    void Update()
    {

    	bool gameScene;
    	int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    	if(currentSceneIndex > 0 && currentSceneIndex < 4){
    		gameScene = true;
    	} else {
    		gameScene = false;
    	}
    	if(gameScene){
    		roundNum.text = "Round " + currentSceneIndex.ToString();
    		timer -= Time.deltaTime;
    		timeDisplay.text = timer.ToString("0.0");

    		if(Input.GetMouseButtonDown(0)){
        		clicks++;
        	
        		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        		RaycastHit2D hit = Physics2D.Raycast(mousePos2D,Vector2.zero);
        	
        		if(hit.collider != null){
        		
        			if(hit.collider.gameObject.tag == "enemyHI"){
        				Destroy(hit.collider.gameObject);
        				GameData.score += 20 * currentSceneIndex;
        				targetsHit++;
        			} else if(hit.collider.gameObject.tag == "enemyLOW"){
        				Destroy(hit.collider.gameObject);
        				GameData.score += 10 * currentSceneIndex;
        				targetsHit++;
        			}
        			if(GameData.score > GameData.scoreHI){
        				GameData.scoreHI = GameData.score;
        			}
        		}
        		if(hit.collider == null && clicks >= 5){
        			SceneManager.LoadScene("GameOver");
        		}
        	}
        	//score.text = GameData.score.ToString();
        	if(targetsHit >= 2){
        		int nextSceneIndex = currentSceneIndex + 1;
        		SceneManager.LoadScene(nextSceneIndex);
        	}
        	if(timer <= 0){
        		SceneManager.LoadScene("GameOver");
        	}
    	}
    	if(!gameScene){
    		if(Input.GetKeyUp(KeyCode.Space)){
    			SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    		}
    		if(currentSceneIndex == 4){
    			scoreHI.text = GameData.scoreHI.ToString();
    		}

    	}
    	score.text = GameData.score.ToString();

        
    }
}
