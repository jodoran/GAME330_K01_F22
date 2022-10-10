using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ExamplePlayerMovement : MonoBehaviour {

    public float TurnSpeed = 120.0f;
    public float MoveSpeed = 8.0f;
    public float JumpPower = 10f;

    Animator myAnim;
    bool canJump;

    //bool facingR = true;

    SpriteRenderer sr;

	// Use this for initialization
	void Start () 
    {
        myAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
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
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
            myAnim.SetBool("IsMove", true);
            flip(true);
        }
        else if (FigmentInput.GetButton(FigmentInput.FigmentButton.RightButton))
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            myAnim.SetBool("IsMove", true);
            flip(false);
        }

        else if (FigmentInput.GetButton(FigmentInput.FigmentButton.ActionButton))
        {
            //if (collision.gameObject.CompareTag("Boundary") == true)
            //{
            //    myAnim.SetBool("Jump", false);
            //    canJump = true;
            //}
            //need to check on ground
            transform.Translate(Vector2.up * JumpPower * Time.deltaTime);
            myAnim.SetBool("IsJump", true);
        }
        else
        {
            myAnim.SetBool("IsJump", false);
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
