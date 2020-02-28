using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	Rigidbody2D rb;

	Vector2 force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;
        if(Input.GetKey(KeyCode.A)){
        	force.x = -10;
        } else if(Input.GetKey(KeyCode.D)){
        	force.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            force.y = 300;
        }
    }

    
    private void FixedUpdate()
    {
    	rb.AddForce(force);
    	rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-5,5), rb.velocity.y);
    	Debug.Log(rb.velocity.x);
    }
}
