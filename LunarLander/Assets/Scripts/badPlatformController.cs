using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badPlatformController : MonoBehaviour
{
    float x_speed;
    float x_range_min, x_range_max;
    float range = 1;
    bool move = false;
    // Start is called before the first frame update
    void Start()
    {
        //x_speed = Random.Range(1, 4) / 4;
        x_speed = 1;
        x_range_min = transform.position.x - range;
        x_range_max = transform.position.x + range;
    }

    // Update is called once per frame
    void Update()
    {
        //use collider as trigger
        //if TRIGGERED goto ending scene, message = Landing Failed

        //possible feature to make platforms move
        if (move)
        {
            Vector3 pos = transform.position;
            if (pos.x <= x_range_min)
            {
                x_speed = Mathf.Abs(x_speed);
            }
            else if (pos.x >= x_range_max)
            {
                x_speed = -(Mathf.Abs(x_speed));
            }
            pos.x += x_speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //goto ending scene
            //endmsg = "failed landing"
        }
    }
}
