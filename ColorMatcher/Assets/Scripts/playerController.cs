using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody rb;
    Vector3 torque;
    float speed = 6.0f;
    float turning_speed = 60.0f;
    string direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
        } else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = - transform.forward * speed;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * turning_speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * turning_speed);
        }
    }
    private void FixedUpdate()
    {
        
        
        //rb.AddTorque(torque * force);
    }
}
