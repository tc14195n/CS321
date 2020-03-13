using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public Transform bg_transform;
    public float bg_move;
    public float feet_x, feet_y;
    public LayerMask ground;
    //public SpriteRenderer bg;
    AudioSource audioSource;
    public AudioClip clipJump;
    bool isJumping = false;
    bool facingRight = true;
    //bool isWalking = false;
    Rigidbody2D rb;
    Animator anim;
    Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        bg_move = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        feet_x = 0.1f;
        feet_y = 4.2f;
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
        if(Input.GetKey(KeyCode.D)){
            force.x = 10;
            //isWalking = true;

        } else if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x - feet_x, transform.position.y - feet_y);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
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
                Flip();
            }
        } else if(force.x < 0)
        {
            if (facingRight)
            {
                Flip();
            }
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
            //Debug.Log("NOT WALKING");
        }

    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            audioSource.clip = clipJump;
            audioSource.Play();
            force.y = 400;
            
            isJumping = false;
        }
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), Mathf.Clamp(rb.velocity.y, -5, 6.5f));
        Vector3 groupMove = bg_transform.position;
        MoveGroup(groupMove);
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    void MoveGroup(Vector3 moveVector)
    {
        bg_transform.position += moveVector;
    }
}
