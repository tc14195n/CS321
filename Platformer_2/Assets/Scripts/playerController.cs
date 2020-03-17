using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Player
 * Controls A(walk left),D(walk right), Space(jump)
 * detect if falling into pit
 * detect if hit by enemy
 * subtract health
 * if health damaged, subtract, then die
 * animations: walk/run, jump
 * SFX: jump, hurt, death
 *
 */

public class playerController : MonoBehaviour
{
    [SerializeField] private LayerMask ground;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    //add this in later
    //Animator animate;
    bool isJumping ;
    bool grounded;
    Vector2 force;
   
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        grounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
        Vector3 pos = transform.position;
        //check ground
        checkGround();
        //jump -> false when landed

        //Player Controls
        
        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;
            //pos.x -= 2 * Time.deltaTime;
            //walking animation TRUE
        } else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
            //pos.x += 2 * Time.deltaTime;
            //walking animation TRUE
        } else
        {
            //walking animation FALSE
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            //force.y = 400;

        }
        transform.position = pos;

        
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            force.y = 300;
            //jumping animation TRUE
            //force jump
            rb.AddForce(force);
            //rb.velocity = new Vec
            isJumping = false;
        }
    }
    void checkGround()
    {
        float extraheight = 0.1f;
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraheight, ground);
        Color rayColor;
        if(raycast.collider != null)
        {
            rayColor = Color.green;
        } else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x,0), Vector2.down * (boxCollider.bounds.extents.y + extraheight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraheight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraheight), Vector2.right * (boxCollider.bounds.extents.y + extraheight), rayColor);


        //updates "grounded" variable every frame
        //activates landing SFX if necessary
        //if
    }
}
