using UnityEngine;
using System.Collections;

public class rotationAngle : MonoBehaviour {
	private float Rotation;
	private bool aimUp;
	private bool aimFwd;
	private bool aimBwd;
	private bool aimDown;
	void Update() {
		transform.eulerAngles = new Vector3 (0, 0, 45 * Rotation);

		checkKeys ();
		execute ();
	}

	void checkKeys(){

		if (Input.GetKeyDown ("up")) {
			aimUp = true;
		} else if (Input.GetKeyUp ("up")) {
			aimUp = false;
		}

		if (Input.GetKeyDown ("right")) {
			aimFwd = true;
		} else if (Input.GetKeyUp ("right") || Input.GetKeyUp ("left")) {
			aimFwd = false;
		}


		if (Input.GetKeyDown ("left")) {
			aimBwd = true;
		} else if (Input.GetKeyUp ("left")) {
			aimBwd = false;
		}
			

		if (Input.GetKeyDown ("down")) {
			aimDown = true;
		} else if (Input.GetKeyUp ("down")) {
			aimDown = false;
		}

	}


	void execute(){

			if (aimUp) {
			Rotation = 2;
		} else if (!aimUp) {
			Rotation = 0;
		}
			if (aimUp && aimFwd) {
			Rotation = 1;
		} else if (aimFwd) {
			Rotation = 0;
		}

		if (aimUp && aimBwd) {
			Rotation = 3;
		} else if (aimBwd) {
			Rotation = 4;
		}

		if (aimDown && aimFwd) {
			Rotation = -1;
		} else if (aimDown) {
			Rotation = -2;
		}

		if (aimDown && aimBwd) {
			Rotation = 5;
		} 

	}
}
