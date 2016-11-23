using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	bool Ground;
	bool Left;
	bool Right;
	bool isCrouched = false;

	int Speed = 5;
	int jumpPower = 750;

	float crouchHeight = 0.5f;
	float standHeight = 1f;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			Left = true;
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			Right = true;
		}
		if (Input.GetKeyDown (KeyCode.W) && Ground == true) 
		{
			jump ();
		}
		if(Input.GetKeyDown (KeyCode.S) && Ground == true)
		{
			crouch ();
		}

		if (Input.GetKeyUp (KeyCode.A)) 
		{
			Left = false;
		}
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			Right = false;
		}
		if(Input.GetKeyUp (KeyCode.S) && Ground == true)
		{
			standup ();
		}
	}

	void FixedUpdate ()
	{
		if (Left == true) 
		{
			transform.Translate (Vector3.left * Speed * Time.deltaTime);
		}
		if (Right == true) 
		{
			transform.Translate (Vector3.right * Speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "ground") 
		{
			Ground = true;
		}
	}
	void OnCollisionExit2D(Collision2D coll)
	{
		Ground = false;
	}

	void jump ()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower * Time.deltaTime);
	}
	void crouch ()
	{
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (1,crouchHeight);
		Speed = Speed / 3;
		isCrouched = true;
	}
	void standup ()
	{
		gameObject.GetComponent<BoxCollider2D> ().size = new Vector2 (1,standHeight);
		Speed = Speed * 3;
		isCrouched = false;
	}
}
