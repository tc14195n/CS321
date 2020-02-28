using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diamondController : MonoBehaviour
{
	float speed;
	int x_direction = -1,y_direction = -1;
	int roundNum;

    // Start is called before the first frame update
    void Start()
    {
    	roundNum =  SceneManager.GetActiveScene().buildIndex;
        speed = Random.Range(3,5);
        Vector3 pos = transform.position;
    	pos.x = Random.Range(-4,5);
    	pos.y = Random.Range(-4,5);
    	transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.y += y_direction * Time.deltaTime * speed * roundNum;
        if(pos.y < -5){
        	y_direction = 1;
        } else if(pos.y > 5){
        	y_direction = -1;
        }
        pos.x += x_direction * Time.deltaTime * speed * roundNum;
        if(pos.x < -5){
        	x_direction = 1;
        } else if(pos.x > 5){
        	x_direction = -1;
        }
        transform.position = pos;
    }
}
