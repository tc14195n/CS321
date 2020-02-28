using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorController : MonoBehaviour
{
    // Start is called before the first frame update
    float x_speed = 1;
    float y_speed = -1;
    float rotateSpeed = 45;

    void Start()
    {
        rotateSpeed = Random.Range(1,4) * 60;
        //speed = Random.Range(-5,-2);
    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 pos = transform.position;
    	pos.y += y_speed * Time.deltaTime;
        pos.x += x_speed * Time.deltaTime;
    	transform.position = pos;

        //transform.Translate(x_speed*Time.deltaTime, y_speed*Time.deltaTime, 0);

        //transform.Rotate(0, 0, rotateSpeed*Time.deltaTime); 
    }
}
