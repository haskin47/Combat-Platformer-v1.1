using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;

public class PlayerControl : MonoBehaviour {

    [SerializeField] float      movespeed = 4.0f;
    [SerializeField] float      jumpforce = 7.5f;
    [SerializeField] bool       m_noBlood = false;
    //[SerializeField] GameObject m_slideDust;

    private Animator            animator;
    private Rigidbody2D         rigidbody;
    private SpriteRenderer      sprite;
    private BoxCollider2D       collider;

    private bool                grounded = false;
    private int                 m_facingDirection = 1;
    private float               dirx = 0f;

    private float               m_delayToIdle = 0.0f;
    public bool                isDead;


    
    private enum MovementState { idle, running, jumping, falling}   //  0, 1, 2, 3
    //MovementState state = MovementState.idle;

    // Use this for initialization
    void Start ()
    {
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    /*void Update ()
    {
        //  movement state additions
        dirx = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(dirx * movespeed, rigidbody.velocity.y);

        //  If not dead, do this:
        if (isDead == false) 
        { 
            //Check if character just landed on the ground
            if (!grounded && rigidbody.velocity.y < 0.01)
            {
                grounded = true;
                animator.SetBool("Grounded", grounded);
                Debug.Log("Grounded");
            }

            //Check if character just started falling
            if (grounded && rigidbody.velocity.y > 0.01)
            {
                grounded = false;
                animator.SetBool("Grounded", grounded);
                Debug.Log("Flying");
            }

            // -- Handle input and movement --
            //  tutorial 3, around 8 minutes
            float inputX = Input.GetAxis("Horizontal");

            // Swap direction of sprite depending on walk direction
            if (inputX > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                m_facingDirection = 1;
            }
            
            else if (inputX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                m_facingDirection = -1;
            }

            // Move
            rigidbody.velocity = new Vector2(inputX * m_speed, rigidbody.velocity.y);

            //Set AirSpeed in animator
            animator.SetFloat("AirSpeedY", rigidbody.velocity.y);

            // -- Handle Animations --
        
            //Jump
            if (Input.GetKeyDown("space") && rigidbody.velocity.y < 0.01)
            {
                animator.SetTrigger("Jump");
                grounded = false;
                animator.SetBool("Grounded", grounded);
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, m_jumpForce);
                //  m_groundSensor.Disable(0.2f);
            }

            //Run
            else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            {
                // Reset timer
                m_delayToIdle = 0.05f;
                animator.SetInteger("AnimState", 1);
            }

            //Idle
            else
            {
                // Prevents flickering transitions to idle
                m_delayToIdle -= Time.deltaTime;
                    if(m_delayToIdle < 0)
                        animator.SetInteger("AnimState", 0);
            }
        }
    }
    */
    
    
    private void Update ()
    {

        if (isDead == false)
        {
            dirx = Input.GetAxisRaw("Horizontal");
            rigidbody.velocity = new Vector2(dirx * movespeed, rigidbody.velocity.y);

            if (Input.GetButtonDown("Jump"))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpforce);
            }

            UpdateAnimationState(); //  18:39
        }
        
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if(dirx > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirx < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        
        if(rigidbody.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if(rigidbody.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("AnimState", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            grounded = true;
        }

        //  If you hit a trap, die
        if (collision.gameObject.CompareTag("Trap") == true)
        {
            isDead = true;

            animator.SetBool("noBlood", m_noBlood);
            animator.SetTrigger("Death");

        }
    }

    //  Maybe set a timer, after a few seconds dead, trigger page?
}
