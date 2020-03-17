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
    public float x_drag;
    [SerializeField] private LayerMask ground;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    Animator anima;
    bool isJumping ;
    bool grounded;
    bool facingRight;
    Vector2 force;
    int health;
   
    // Start is called before the first frame update
    void Start()
    {
        x_drag = 1;
        facingRight = (transform.localScale.x > 0)?true:false;
        health = 3;
        anima = GetComponent<Animator>();
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

            Walking(-10f);
            //pos.x -= 2 * Time.deltaTime;
            //walking animation TRUE
        } else if (Input.GetKey(KeyCode.D))
        {
            Walking(10f);
            //pos.x += 2 * Time.deltaTime;
            //walking animation TRUE
        } else
        {
            if (grounded)
            {
                //force.x = 0;
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            
            
            anima.SetBool("isWalking", false);
            //walking animation FALSE
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumping = true;
            //force.y = 400;

        }
        transform.position = pos;
        //Debug.Log("x force: " + force.x);

        
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            force.y = 300;
            anima.SetBool("isJumping", true);
            isJumping = false;
        }
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), Mathf.Clamp(rb.velocity.y, -5, 6.5f));
    }
    void checkGround()
    {
        float extraheight = 0.1f;
        RaycastHit2D raycast = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraheight, ground);
        //Color rayColor;
        if(raycast.collider != null)
        {
            if (!grounded)
            {
                anima.SetBool("isJumping", false);
            }
            grounded = true;
            anima.SetBool("isJumping", false);
            //rayColor = Color.green;
        } else
        {
            grounded = false;
            //rayColor = Color.red;
        }
        //Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x,0), Vector2.down * (boxCollider.bounds.extents.y + extraheight), rayColor);
        //Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraheight), rayColor);
        //Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraheight), Vector2.right * (boxCollider.bounds.extents.y + extraheight), rayColor);


        //updates "grounded" variable every frame
        //activates landing SFX if necessary
        //if
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    void Walking(float walkForce)
    {
        force.x = walkForce;
        if(walkForce < 0)
        {
            if (facingRight)
            {
                Flip();
            }
            anima.SetBool("isWalking", true);
        } else
        {
            if (!facingRight)
            {
                Flip();
            }
            anima.SetBool("isWalking", true);
        }
    }
}
