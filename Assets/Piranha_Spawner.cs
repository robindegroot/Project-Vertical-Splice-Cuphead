using UnityEngine;
using System.Collections;

public class Piranha_Spawner : MonoBehaviour {
	public EnemyProjectile_ projectile;
	public Transform muzzle;
	public float bulletSpeed;
	public float fireRate = 2.0F;
	private float nextFire = 2.0F;

	void Start (){
		nextFire = Time.time + fireRate;
	}

	void Update()
	{

		Shoot ();
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
