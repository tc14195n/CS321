using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class circleController : MonoBehaviour
{
    // Start is called before the first frame update
    int speed;
    int roundNum;
    void Start()
    {
    	roundNum = SceneManager.GetActiveScene().buildIndex;
    	Vector3 pos = transform.position;
    	pos.x = Random.Range(-3,4);
    	pos.y = Random.Range(-3,4);
    	transform.position = pos;
    	speed =  Random.Range(3,8);
    }

    // Update is called once per frame
    void Update()
    {
    	transform.Translate(0,speed * Time.deltaTime, 0);
        transform.Rotate(0,0,360 * roundNum * Time.deltaTime);
    }
}
