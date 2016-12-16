using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public EnemyProjectile_ projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float fireRate = 2.0F;
	private float nextFire = 2.0F;
	bool Active;

	void Start (){
		nextFire = Time.time + fireRate;
	}

	void Update()
	{
		//bool Active = GameObject.Find("Muzzle").GetComponent<EnemyShootLR>().active;

		if (GameObject.Find("Muzzle").GetComponent<EnemyShootLR>().active) {
			Shoot ();
		}


	}

	public void Shoot()
	{
		if (Time.time >= nextFire)
		{
			EnemyProjectile_ newProjectile = Instantiate (
				projectile,
				muzzle.position,
				muzzle.rotation) as EnemyProjectile_;
			nextFire = Time.time + fireRate;
		}

	}



}
