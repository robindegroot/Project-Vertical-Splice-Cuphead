using UnityEngine;
using System.Collections;

public class EnemyProjectile_ : MonoBehaviour {
	private float nextFire = 7;
	public float power;



	void Start () {
		this.GetComponent<Rigidbody2D> ().AddForce (transform.up * power * Time.deltaTime);
		Destroy (gameObject, 5f);
	}



	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag== "Wall" || other.gameObject.tag == "ground") {
			Destroy (gameObject, 0f);
		}


	}
}
