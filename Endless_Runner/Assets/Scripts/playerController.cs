using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody player_rb;
    Vector3 force;
    float z_speed, x_speed;
    float jump_force;
    SphereCollider sphere_col;
    [SerializeField] private LayerMask ground;
    bool grounded;
    // Start is called before the first frame update
    //float last_built = -5;
    void Start()
    {
        grounded = false;
        sphere_col = GetComponent<SphereCollider>();
        player_rb = GetComponent<Rigidbody>();
        z_speed = 20;
        x_speed = 15;
        jump_force = 200;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(grounded);
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
            //player_rb.AddForce(force);
        } else if (Input.GetKey(KeyCode.S))
        {
            force.z = -z_speed;
            //player_rb.AddForce(force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            force.x = -x_speed;
            //player_rb.AddForce(force);
        } else if (Input.GetKey(KeyCode.D))
        {
            force.x = x_speed;
            //player_rb.AddForce(force);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            force.y = jump_force;
            //player_rb.AddForce(force);
        }

    }
    private void FixedUpdate()
    {
        player_rb.AddForce(force);
        player_rb.velocity = new Vector3(Mathf.Clamp(player_rb.velocity.x, -4, 4), Mathf.Clamp(player_rb.velocity.y, -6, 6), Mathf.Clamp(player_rb.velocity.z, -10, 10));
        //if()
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OOB")
            GameData.setGameOver(true);
    }
    */
    private void checkGround()
    {
        /*
        float extra_height = 0.3f;
        bool grounded = Physics.BoxCast(sphere_col.bounds.center,sphere_col.bounds.size/2, Vector3.down, Quaternion.identity, extra_height, ground);
        return grounded;
        */
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "floor_tile")
        {
            grounded = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "floor_tile")
        {
            grounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "floor_tile")
        {
            grounded = false;
        }
    }
}
