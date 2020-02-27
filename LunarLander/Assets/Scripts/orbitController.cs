using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitController : MonoBehaviour
{
    float rotate_speed, x_speed,y_speed;
    // Start is called before the first frame update
    void Start()
    {
        rotate_speed = 45;
        x_speed = 1;
        y_speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotate_speed * Time.deltaTime);
        //Below x_speed only ->-> causes item to orbit around center orientation top always facing in
        //transform.Translate(x_speed * Time.deltaTime, 0, 0);
        //Below x and y speed, sprite flew wildly out of frame
        //transform.Translate(x_speed * Time.deltaTime, y_speed, 0);
        transform.Translate(0, y_speed * Time.deltaTime, 0);
    }
}
