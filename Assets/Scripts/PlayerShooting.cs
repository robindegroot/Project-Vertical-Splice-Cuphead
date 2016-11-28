using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	AudioSource shot;
	public Projectile_ projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float fireRate = 2.0F;
	private float nextFire = 2.0F;

	void Start (){
		nextFire = Time.time + fireRate;
	}

	void Update()
	{

		if (Input.GetKey("i") || Input.GetKey("j") || Input.GetKey("n") && Time.time > nextFire) {
			Shoot ();

		}


	}

	public void Shoot()
	{
		if (Time.time >= nextFire)
		{
			Projectile_ newProjectile = Instantiate (
				projectile,
				muzzle.position,
				muzzle.rotation) as Projectile_;
			nextFire = Time.time + fireRate;
		}

	}
	/*private void Shoot()
	{
		nextFire = Time.time + fireRate;
		Projectile_ newProjectile = Instantiate (
			projectile,
			muzzle.position,
			muzzle.rotation) as Projectile_;
	}*/



}
