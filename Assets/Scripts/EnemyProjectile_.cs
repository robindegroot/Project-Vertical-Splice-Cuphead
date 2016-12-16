using UnityEngine;
using System.Collections;

public class EnemyProjectile_ : MonoBehaviour {
	public float range;
	private float nextFire = 9;



	void Start () {
		GetComponent<Rigidbody2D> ().AddForce (transform.up * range * Time.deltaTime);
		Destroy (gameObject, 5f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag== "Wall" || other.gameObject.tag == "ground") {
			Destroy (gameObject, 0f);
		}


	}
}
