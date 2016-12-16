using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	AudioSource shot;
	public Projectile_ projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float fireRate = 2.0F;
	private float nextFire = 2.0F;
	public bool moving;
	public bool shoot;

	void Start (){
		nextFire = Time.time + fireRate;
	}

	void Update()
	{
		Debug.Log (shoot);
		moving = GameObject.Find("Player").GetComponent<PlayerMovement>().Moving;
		if (moving == false) {
			if (Input.GetKey ("i") || Input.GetKey ("j") || Input.GetKey ("n") && Time.time > nextFire) {
				shoot = true;
				Shoot ();

			} else {
				shoot = false;
			}

		}


	}

	public void Shoot()
	{
		if (Time.time >= nextFire)
		{
			nextFire = Time.time + fireRate;
			Projectile_ newProjectile = Instantiate (
				projectile,
				muzzle.position,
				muzzle.rotation) as Projectile_;
			
		}

	}



}
