using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;

public class ExamplePlayerMovement : MonoBehaviour {

    public float TurnSpeed = 120.0f;

    public float MoveSpeed = 80f;
    public float JumpPower = 10f;
    public GameObject cam;
    public GameObject UIpopup;
    public PlayerHealth playerHealth;

    public GameObject winpanel;


    public AudioClip jump;
    public AudioClip win;


    Animator myAnim;
    public bool canJump;
    int useStair = 0;
    //bool facingR = true;
    FollowingCamera camS;
    SpriteRenderer sr;
    Rigidbody2D rb;
    AudioSource audioS;

	// Use this for initialization
	void Start () 
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        camS = cam.GetComponent<FollowingCamera>();
        audioS = GetComponent<AudioSource>();
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Check which stair im on
        if(collision.CompareTag("Stair1"))
        {
            UIpopup.SetActive(true);
            useStair = 1;
        }
        if (collision.CompareTag("Stair2"))
        {
            UIpopup.SetActive(true);
            useStair = 2;
        }
        if (collision.CompareTag("Stair3"))
        {
            UIpopup.SetActive(true);
            useStair = 3;
        }
        //End of Game, Exit
        if (collision.CompareTag("Stair4"))
        {
            UIpopup.SetActive(true);
            useStair = 4;
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stair1") || collision.CompareTag("Stair2") || collision.CompareTag("Stair3") || collision.CompareTag("Stair4"))
        {
            UIpopup.SetActive(false);
            useStair = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            myAnim.SetBool("IsJump", false);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = true;
            myAnim.SetBool("IsJump", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            canJump = false;
        }
    }

    // Update is called once per frame
    //void Update () {
    //       if (FigmentInput.GetButton(FigmentInput.FigmentButton.LeftButton))
    //       {
    //           transform.Rotate(Vector3.up, -TurnSpeed * Time.deltaTime);
    //       }
    //       else if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
    //       {
    //           transform.Rotate(Vector3.up, TurnSpeed * Time.deltaTime);
    //       }

    //       if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
    //       {
    //           transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    //       }
    //   }

    void Update()
    {
        if (FigmentInput.GetButton(FigmentInput.FigmentButton.LeftButton))
        {
            rb.AddForce(Vector2.left * MoveSpeed, ForceMode2D.Impulse);
            if (rb.velocity.x < -MoveSpeed)
            {
                rb.velocity = new Vector2(-MoveSpeed, rb.velocity.y);
            }
            //transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
            myAnim.SetBool("IsMove", true);
            flip(true);
        }


        if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
        {
            rb.AddForce(Vector2.right * MoveSpeed,ForceMode2D.Impulse);
            if(rb.velocity.x >MoveSpeed)
            {
                rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
            }
            //transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            myAnim.SetBool("IsMove", true);
            flip(false);
        }

        if (FigmentInput.GetButtonDown(FigmentInput.FigmentButton.ActionButton))
        {

            if (useStair == 5)
            {
                SceneManager.LoadScene("FigmentTestScene");
            }
            if (canJump)
            {
                audioS.PlayOneShot(jump);
                rb.AddForce(new Vector2(0, JumpPower));
                myAnim.SetBool("IsJump", true);
            }

            //First Stair
            if (useStair == 1)
            {
                transform.position = new Vector3(5000f, 14f, 0f);
                camS.cameraY = 15.2f;
                playerHealth.SetStageHealth(60f);

                useStair = 0;
            }
            //Second Stair
            if (useStair == 2)
            {
                transform.position = new Vector3(5000f, 4.64f, 0f);
                camS.cameraY = 5.2f;
                playerHealth.SetStageHealth(40f);
                useStair = 0;
            }
            //Third Stair
            if (useStair == 3)
            {
                transform.position = new Vector3(4970f, -6.01f, 0f);
                camS.cameraY = -4.8f;
                playerHealth.SetStageHealth(30f);

                useStair = 0;
            }
            //Fourth Stair , Exit
            if (useStair == 4)
            {
                winpanel.SetActive(true);
                audioS.PlayOneShot(win);
                useStair = 5;
            }

        }

        if (FigmentInput.GetButtonUp(FigmentInput.FigmentButton.LeftButton))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            myAnim.SetBool("IsMove", false);
        }
        if (FigmentInput.GetButtonUp(FigmentInput.FigmentButton.RightButton))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            myAnim.SetBool("IsMove", false);
        }
    }


    void flip(bool facingR)
    {
        if(facingR)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
