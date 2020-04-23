using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody player_rb;
    Vector3 force;
    float z_speed, x_speed;
    float jump_force;
    // Start is called before the first frame update
    //float last_built = -5;
    void Start()
    {
        player_rb = GetComponent<Rigidbody>();
        z_speed = 50;
        x_speed = 25;
        jump_force = 40;
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector3.zero;
        /*
         * Control scheme:
         * Forward, left, right
         * jump
         * 
         * Camera:
         * Over-the-shoulder style
         * Follows player z-value, doesn't change x or y
         * 
         * Lose Condition:
         * Player y drops below 0
         * Trigger boolean condition in GameManager which sends to GameOver screen
         */
        if (Input.GetKey(KeyCode.W))
        {
            force.z = z_speed;
            player_rb.AddForce(force);
        } else if (Input.GetKey(KeyCode.S))
        {
            force.z = -z_speed;
            player_rb.AddForce(force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            force.x = -x_speed;
            player_rb.AddForce(force);
        } else if (Input.GetKey(KeyCode.D))
        {
            force.x = x_speed;
            player_rb.AddForce(force);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            force.y = jump_force;
            player_rb.AddForce(force);
        }

    }
    private void FixedUpdate()
    {
        //if()
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OOB")
            GameData.setGameOver(true);
    }
}
