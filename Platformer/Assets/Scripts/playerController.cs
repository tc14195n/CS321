using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //public Transform bg_transform;
    //public float bg_move;
    public float feet_x, feet_y;
    public float feet_dim_x, feet_dim_y;
    public LayerMask ground;

    //public SpriteRenderer bg;
    AudioSource audioSource;
    public float x_speed = 3;
    public AudioClip clipJump;

    private SpriteRenderer sprite;
    bool isJumping = false;
    bool facingRight = true;
    //bool isWalking = false;
    Rigidbody2D rb;
    Animator anim;
    Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        //bg_move = 0;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        feet_dim_x = 1.0f;
        feet_dim_y = 0.2f;
        feet_x = 0.1f;
        feet_y = 2.03f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        //check grounded status
        //auto-update grounded = false when character "lands" aka grounded == true
        Vector2 feet = new Vector2(0,0.1f); //feet are bottom 10% of sprite
        Vector2 dimensions = new Vector2(0.2f,0.1f);
        bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
        
        if (grounded)
        {
            Debug.Log("Grounded: " + grounded);
            anim.SetBool("isJumping", false);
        }
        force = Vector2.zero;
        if(Input.GetKey(KeyCode.D)){
            //force.x = 10;
            //isWalking = true;
            pos.x += x_speed * Time.deltaTime;

        } else if (Input.GetKey(KeyCode.A))
        {
            //force.x = -10;
            pos.x -= x_speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (grounded)
            {
                isJumping = true;
            }
            
        }

        if (force.x > 0)
        {
            anim.SetBool("isWalking", true);
            if (!facingRight)
            {
                //Flip();
            }
        } else if(force.x < 0)
        {
            if (facingRight)
            {
                //Flip();
            }
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
            //Debug.Log("NOT WALKING");
        }
        transform.position = pos;

    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            audioSource.clip = clipJump;
            audioSource.Play();
            force.y = 800;
            anim.SetBool("isJumping", true);
            
            isJumping = false;
        }
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), Mathf.Clamp(rb.velocity.y, -5, 6.5f));
        //Vector3 groupMove = bg_transform.position;
        //MoveGroup(groupMove);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    /*
    void MoveGroup(Vector3 moveVector)
    {
        bg_transform.position += moveVector;
    }
    */
}
