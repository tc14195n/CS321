using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipController : MonoBehaviour
{
    float x_speed = 2, y_speed = 3;
    float fuel = 15; //determines how many movements the ship can make before running out
    float fuel_burn = 1; //should be positive. value is subtracted below
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuel > 0) //controls disabled when fuel runs out
        {
            //controls for A, S, D
            if (Input.GetKey(KeyCode.A))
            {
                //move ship right
                transform.Translate(Vector3.right * x_speed * Time.deltaTime);
                fuel -= fuel_burn * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                //move ship left
                transform.Translate(Vector3.left * x_speed * Time.deltaTime);
                fuel -= fuel_burn * Time.deltaTime;

            }
            if (Input.GetKey(KeyCode.S))
            {
                //move ship up
                transform.Translate(Vector3.up * y_speed * Time.deltaTime);
                fuel -= fuel_burn * Time.deltaTime;
            }
        }
        
    }
}
