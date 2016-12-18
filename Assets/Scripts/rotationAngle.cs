using UnityEngine;
using System.Collections;

public class rotationAngle : MonoBehaviour {
	private float Rotation;
	private bool aimUp;
	private bool aimFwd;
	private bool aimBwd;
	private bool aimDown;
	bool left;
	bool right;
	bool flipped;
	public Animator Animator;


	void Start(){

	
	}


	void Update() {
		bool left = GameObject.Find("Player").GetComponent<PlayerMovement>().Left;
		bool right = GameObject.Find("Player").GetComponent<PlayerMovement>().Right;
		bool flipped = GameObject.Find("Player").GetComponent<PlayerMovement>().Flipped;
		transform.eulerAngles = new Vector3 (0, 0, 45 * Rotation);
		checkKeys ();
		if (flipped) {
			executeR ();
		}
		if (!flipped) {
			executeL ();
		}

	}

	void checkKeys(){
		

			/*if (Input.GetKeyDown ("n")) {
				aimUp = true;
				

			} else if (Input.GetKeyUp ("n")) {
				
				aimUp = false;
			}*/

		if (Input.GetKey ("j") && !Input.GetKey("i")) {
			    Shoot ();
				aimFwd = true;
			} else if (Input.GetKeyUp ("j")) {
				Animator.SetBool ("Shoot_Side", false);
				Animator.SetBool ("Still", true);

				aimFwd = false;
			}



		if (Input.GetKey ("i") && Input.GetKey ("j")) {
			aimDown = true;
			aimFwd = true;
			Shoot_Up_Side ();
		} else if (Input.GetKeyUp ("i") && Input.GetKeyUp ("j")) {
			aimFwd = false;
			aimDown = false;
			Animator.SetBool ("Shoot_Up_Side", false);
			Animator.SetBool ("Still", true);
		}


		if (Input.GetKey ("i")) {
			    Shoot_Up ();
				aimDown = true;
			} else if (Input.GetKeyUp ("i")) {
			Animator.SetBool ("Shoot_Up", false);
			Animator.SetBool ("Still", true);
				aimDown = false;
			}

	}


	void executeR(){

		if (aimUp) {
			
			Rotation = 2;
		} else if (!aimUp) {
			Rotation = 0;
		}
		if (aimUp && aimFwd) {
			
			Rotation = 0.5f;
		} else if (aimFwd) {
			
			Rotation = 0;
		}

		if (aimDown && aimFwd) {
			Rotation = -0.5f;
		} else if (aimDown) {
			Rotation = -2;
		}

	}

	void executeL(){
		if (aimUp) {
			Rotation = 2;
		} else if (!aimUp) {
			Rotation = 4;
		}
		if (aimUp && aimFwd) {
			Rotation = 3.5f;
		} else if (aimFwd) {
			Rotation = 4;
		}

		if (aimDown && aimFwd) {
			Rotation = 4.5f;
		} else if (aimDown) {
			Rotation = -2;
		}
	}

	void Shoot(){
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Still", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Shoot_Up", false);
		Animator.SetBool ("Shoot_Up_Side", false);
		Animator.SetBool ("Shoot_Side", true);
	}

	void Shoot_Up_Side(){

		Animator.SetBool ("Still", false);
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Shoot_Up", false);
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Shoot_Up_Side", true);
	}

	void Shoot_Up(){

		Animator.SetBool ("Still", false);
		Animator.SetBool ("Jump", false);
		Animator.SetBool ("Run", false);
		Animator.SetBool ("Shoot_Side", false);
		Animator.SetBool ("Shoot_Up_Side", false);
		Animator.SetBool ("Shoot_Up", true);
	}
}