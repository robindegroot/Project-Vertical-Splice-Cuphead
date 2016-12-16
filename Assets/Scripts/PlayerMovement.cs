using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	public float Speed = 0f;
	public float JumpForce;
	private float move = 0f;
	private bool CanJump;
	public bool Right;
	public bool Left;
	public bool Flipped;
	public bool Ducking;
	public float Rotation;
	public bool Moving = false;

	public Animator Animator;
	void Start(){
		
	}


	void Update(){
		transform.localRotation = Quaternion.Euler (0, Rotation, 0);
		//Debug.Log ();
		checkKeys ();
		if (move < 0 && CanJump && !Ducking) {
			Rotation = 0;
			Run ();

		} else if (move > 0 && CanJump && !Ducking) {
			Rotation = 180;
			Run ();
		} else if (move == 0 && CanJump) {
			Moving = false;
			Animator.SetBool ("Run", false);
			//Rotation = 0;
			//Still ();
		}
		//Debug.Log (move);

	}
		

	void checkKeys(){
		if (Input.GetKeyDown ("d")) {
			//Run ();
			Right = true;
			Left = false;
		} 

		if (Input.GetKeyUp ("d")) {
			Right = !Right;
			//Still ();
		}

		if (Input.GetKeyDown ("a")) {
			
			//Run ();
			Right = false;
			Left = true;

		}

		if (Input.GetKeyUp ("a")) {
			Left = !Left;
			//Still ();
		}

		if (!Right && Left) {
			Flipped = false;
		} else if (Right && !Left) {
			
			Flipped = true;
		}

		if (Input.GetKey ("s") && CanJump) {
			Animator.SetBool ("Run", false);
			Duck ();
			Ducking = true;
		} else if (Input.GetKeyUp ("s") && CanJump) {
			Speed = 10;
			Ducking = false;
			Still ();
		}
	}




	void OnCollisionStay2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "ground") 
		{
			CanJump = true;
	}
		if (coll.gameObject.tag == "ground" && Right || coll.gameObject.tag == "ground" && Left) {
			//Run ();
		} else {
			if (!Ducking) {

				Still ();
			}
		}
	}
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "ground") {
			CanJump = false;
		}
	}

	void FixedUpdate () {
		move = Input.GetAxis ("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * -Speed, GetComponent<Rigidbody2D>().velocity.y);
		if (Input.GetKey (KeyCode.W)  && CanJump)
		{
			Jump ();
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (GetComponent<Rigidbody2D>().velocity.x,JumpForce));
			CanJump = false;

		}
	}

	void Run(){
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Still", false);
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Run", true);
	}



	void Still(){
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Duck", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Still", true);
	}

	void Jump(){
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Still", false);
		Animator.SetBool ("Jump", true);
	}

	void Duck(){
	   
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Still", false);
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Duck", true);
		Speed = 0;
	}
}