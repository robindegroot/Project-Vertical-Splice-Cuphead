using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class NewPlayerMovement : MonoBehaviour
{

    public float Speed = 0f;
    public float JumpForce;
    private float move = 0f;
    private bool CanJump;
    public bool Right;
    public bool Left;
    public bool Flipped;

    void Update()
    {
        if (Input.GetKeyDown("d"))
        {
            Right = true;
            Left = false;
        }

        if (Input.GetKeyDown("a"))
        {
            Right = false;
            Left = true;
        }

        if (!Right && Left)
        {
            Flipped = false;
        }
        else if (Right && !Left)
        {
            Flipped = true;
        }
    }




    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            CanJump = true;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "ground")
        {
            CanJump = false;
        }
    }

    void FixedUpdate()
    {
        move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * Speed, GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKey(KeyCode.W) && CanJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpForce));
            CanJump = false;

        }
    }
}