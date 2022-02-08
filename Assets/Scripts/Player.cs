using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    //public float gravityScale = 10;
    //public float fallingGravityScale = 40;
    public Animator anim;
    private const float minHeldTime = 0.15f;
    private float spacePressedTime = 0;
    private bool spaceHeld = false;
    private bool isGrounded = true;
    public GameController gameController;
    //public Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //retryButton = GameObject.FindWithTag("RetryButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // Space key is pressed, unclear whether it'll be released or held
            spacePressedTime = Time.timeSinceLevelLoad;
            spaceHeld = false;
        } else if (Input.GetKeyUp(KeyCode.Space))
        {
            if (!spaceHeld && isGrounded == true) {
                // Space button has been released
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                isGrounded = false;
                gameController.jump1a.GetComponent<AudioSource>().Play();
            }
            spaceHeld = false;
        }

        //if (!isGrounded && Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        //}

        if (Input.GetKey(KeyCode.D))
        {
            //rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.timeSinceLevelLoad - spacePressedTime > minHeldTime && isGrounded == true)
            {
                // Space button has been held for .25 seconds, it is now "held"
                rb.AddForce(Vector2.up * (jumpAmount-(jumpAmount/3)), ForceMode2D.Impulse);
                isGrounded = false;
                gameController.jump1a.GetComponent<AudioSource>().Play();
            }
        }

        if (isGrounded)
        {
            anim.Play("CacteroWalk");
        }
        else
        {
            anim.Play("CacteroJump");
        }

        //if(rb.velocity.y >= 0)
        //{
        //    rb.gravityScale = gravityScale;
        //}

        //else if (rb.velocity.y < 0)
        //{
        //    rb.gravityScale = fallingGravityScale;
        // }

    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameController.GameOver();
            Time.timeScale = 0;
        }
    }
    
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }    

    }


}
