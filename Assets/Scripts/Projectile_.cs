using UnityEngine;
using System.Collections;

public class Projectile_ : MonoBehaviour {
	
	public float _speed;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 1f);
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector2.right * _speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy" || other.tag == "Wall") {
			Destroy (gameObject, 0f);
		}


	}

	public void SetSpeed(float value) {
		_speed = value;
	}
}
