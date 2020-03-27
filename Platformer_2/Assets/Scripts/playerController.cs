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
    float x_dist,y_dist, fade_time;
    public float x_drag;
    [SerializeField] private LayerMask ground;
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    Animator anima;
    bool isJumping, grounded, facingRight;
    Vector2 force;
    int health;
    bool invul; //invulnerable period after being hit. blinks during this time
    public GameObject heart1, heart2, heart3;
    Transform trans_heart1, trans_heart2, trans_heart3;
    SpriteRenderer rend_heart1, rend_heart2, rend_heart3;
    SpriteRenderer sprite;
    private new AudioSource audio;
    public AudioClip jumpClip, damageClip;
       
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        invul = false;
        fade_time = 0.006f;
        x_dist = 0.4f;
        y_dist = 0.7f;
        trans_heart1 = heart1.GetComponent<Transform>();
        trans_heart2 = heart2.GetComponent<Transform>();
        trans_heart3 = heart3.GetComponent<Transform>();
        rend_heart1 = heart1.GetComponent<SpriteRenderer>();
        rend_heart2 = heart2.GetComponent<SpriteRenderer>();
        rend_heart3 = heart3.GetComponent<SpriteRenderer>();
        Vector3 pos1 = transform.position;
        Vector3 pos2 = transform.position;
        Vector3 pos3 = transform.position;
        pos1.x -= x_dist;
        pos3.x += x_dist;
        pos1.y = transform.position.y + y_dist;
        pos2.y = transform.position.y + y_dist;
        pos3.y = transform.position.y + y_dist;

        trans_heart1.position = pos1;
        trans_heart2.position = pos2;
        trans_heart3.position = pos3;

        x_drag = 1;
        facingRight = (transform.localScale.x > 0)?true:false;
        health = 3;
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        isJumping = false;
        grounded = false;
        StartCoroutine(Fade(rend_heart1, 0f));
        StartCoroutine(Fade(rend_heart2, 0f));
        StartCoroutine(Fade(rend_heart3, 0f));
    }

    void Update()
    {
        Vector3 pos1 = transform.position;
        Vector3 pos2 = transform.position;
        Vector3 pos3 = transform.position;
        pos1.x -= x_dist;
        pos3.x += x_dist;
        pos1.y = transform.position.y + y_dist;
        pos2.y = transform.position.y + y_dist;
        pos3.y = transform.position.y + y_dist;
        trans_heart1.position = pos1;
        trans_heart2.position = pos2;
        trans_heart3.position = pos3;

        

        force = Vector2.zero;
        Vector3 pos = transform.position;

        checkGround();
        
        if (Input.GetKey(KeyCode.A) && health > 0)
        {
            GameData.bg_move += 0.0001f;
            Walking(-10f);
        } else if (Input.GetKey(KeyCode.D) && health > 0)
        {
            GameData.bg_move -= 0.0001f;
            Walking(10f);
        } else
        {
            if (grounded)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            
            
            anima.SetBool("isWalking", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded && health > 0)
        {
            isJumping = true;
        }
        transform.position = pos;        
    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            force.y = 300;
            anima.SetBool("isJumping", true);
            //audio.clip = jumpClip;
            //audio.Play();
            SFXManager.Play(jumpClip,0.5f);
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!invul)
            {
                Debug.Log("HIT");
                //audio.clip = damageClip;
                //audio.Play();
                
                StartCoroutine(Fade(rend_heart1, 1f));
                StartCoroutine(Fade(rend_heart2, 1f));
                StartCoroutine(Fade(rend_heart3, 1f));
                switch (health)
                {
                    case 3:
                        SFXManager.Play(damageClip);
                        StartCoroutine(Blink());
                        Animator anim = heart1.GetComponent<Animator>();
                        anim.SetBool("heartLost", true);
                        anim.SetBool("stop", true);
                        //StartCoroutine(Fade(rend_heart1, 0f));
                        //StartCoroutine(Fade(rend_heart2, 0f));
                        //StartCoroutine(Fade(rend_heart3, 0f));
                        health--;
                        break;
                    case 2:
                        SFXManager.Play(damageClip);
                        StartCoroutine(Blink());
                        anim = heart2.GetComponent<Animator>();
                        anim.SetBool("heartLost", true);
                        anim.SetBool("stop", true);
                        //StartCoroutine(Fade(rend_heart1, 0f));
                        //StartCoroutine(Fade(rend_heart2, 0f));
                        //StartCoroutine(Fade(rend_heart3, 0f));
                        health--;
                        break;
                    case 1:
                        SFXManager.Play(damageClip);
                        anim = heart3.GetComponent<Animator>();
                        anim.SetBool("heartLost", true);
                        anim.SetBool("stop", true);
                        //StartCoroutine(Fade(rend_heart1, 0f));
                        //StartCoroutine(Fade(rend_heart2, 0f));
                        //StartCoroutine(Fade(rend_heart3, 0f));
                        health--;
                        anima.SetBool("isDead", true);
                        break;
                    default:
                        break;
                }
                
            }
                
        }
    }
    IEnumerator Fade(SpriteRenderer heart, float fade_to)
    {
        Color color = heart.material.color;
        if(fade_to == 0)
        {
            while (color.a > 0)
            {
                color.a -= fade_time;// * Time.deltaTime;
                if (color.a < 0)
                {
                    color.a = 0;
                }
                heart.material.color = color;
                
                yield return null;
            }
        } else if(fade_to == 1)
        {
            while (color.a < 1)
            {
                color.a += fade_time/2;
                if(color.a > 1)
                {
                    color.a = 1;
                }
                heart.material.color = color;
                yield return null;
            }
        }
        
        
        
    }
    IEnumerator Blink()
    {
        invul = true;
        Color color = sprite.material.color;
        color.a = 0.5f;
        sprite.material.color = color;
       
        yield return new WaitForSeconds(2);
        invul = false;
        color.a = 1f;
        sprite.material.color = color;
    }
}
