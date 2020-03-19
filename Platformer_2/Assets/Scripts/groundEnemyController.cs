using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundEnemyController : MonoBehaviour
{
    bool facingRight;
    Animator anima;
    CircleCollider2D cCol;
    // Start is called before the first frame update
    void Start()
    {
        facingRight = (transform.localScale.x > 0) ? true : false;
        anima = GetComponent<Animator>();
        cCol = GetComponent<CircleCollider2D>();
        anima.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        facingRight = !facingRight;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Skeleton collision: " + collision.name);
        if(collision.gameObject.tag == "Player")
        {
            
            anima.SetBool("seesPlayer", true);
            Debug.Log("OnEnter: Sees Player");
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.transform.position.x < transform.position.x && facingRight)
        {
            Flip();
        }
        else if (collision.gameObject.transform.position.x >= transform.position.x && !facingRight)
        {
            Flip();
        }
        Debug.Log("OnStay: Sees Player");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            anima.SetBool("seesPlayer", false);
        }
    }
    
}
