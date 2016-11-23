using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	bool Ground;
	public bool Left;
	public bool Right;
	public bool Flipped;
	public int Speed;
	public int jumpPower;

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			Left = true;
			Flipped = false;
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			Right = true;
			Flipped = true;
		}
		if (Input.GetKeyUp (KeyCode.A)) 
		{
			Left = false;
		}
		if (Input.GetKeyUp (KeyCode.D)) 
		{
			Right = false;
		}
		if (Input.GetKeyDown (KeyCode.W) && Ground == true) 
		{
			jump ();
		}
		if(Input.GetKeyDown (KeyCode.S) && Ground == true)
		{
			crouch ();
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
		//bukken
	}
	void standup ()
	{
		//opstaan
	}
}