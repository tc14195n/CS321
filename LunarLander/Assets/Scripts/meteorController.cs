using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorController : MonoBehaviour
{
    // Start is called before the first frame update
    float x_speed;
    float y_speed;
    float rotateSpeed = 45;
    Vector3 orig_pos;

    void Start()
    {
        orig_pos = transform.position;
        x_speed = Random.Range(5, 16) / 5;
        y_speed = -x_speed;
        rotateSpeed = Random.Range(1, 4) * 60;
        //speed = Random.Range(-5,-2);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if(pos.y < -10)
        {
            pos.y = orig_pos.y;
            pos.x = orig_pos.x;
        } else
        {
            pos.y += y_speed * Time.deltaTime;
            pos.x += x_speed * Time.deltaTime;
        }
        
        transform.position = pos;

        //transform.Translate(x_speed*Time.deltaTime, y_speed*Time.deltaTime, 0);

        transform.Rotate(0, 0, rotateSpeed*Time.deltaTime); 
    }
}
