using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public LayerMask ground;
	Rigidbody2D rb;
    Animator anim;
	Vector2 force;
    bool facingRight = true;
    bool jumpPending = false;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;

        if (Input.GetKey(KeyCode.A)){
        	force.x = -10;
        } else if(Input.GetKey(KeyCode.D)){
        	force.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x - 0.1f, transform.position.y - 0.45f);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);
            Debug.Log(grounded);

            if (grounded)
                jumpPending = true;
        }
        if(force.x < 0)
        {
            anim.SetBool("isWalking", true);
            if (facingRight)
                Flip();
        } else if(force.x > 0)
        {
            anim.SetBool("isWalking", true);
            if (facingRight == false)
                Flip();
        } else
        {
            anim.SetBool("isWalking", false);
        }

    }

    
    private void FixedUpdate()
    {   
        if(jumpPending)
        {
            force.y = 400;
            jumpPending = false;
        }
    	rb.AddForce(force);
    	rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-5,5), Mathf.Clamp(rb.velocity.y,-5,6.5f));
        //Debug.Log(transform.position.x + ", " + transform.position.y);
        //Debug.Log("force: " + rb.velocity);

    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
}
