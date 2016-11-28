using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	//moeten we helemaal verander
    public static EnemyShoot enemyShoot;
    private GameObject player;
    [SerializeField]
    private Transform muzzle;

//    public EnemyProjectile projectile;
    private float bulletSpeed;
    private float firerate;
    private float nextFireTime;

    void Start ()
    {
        bulletSpeed = 20f;
        firerate = 5f;
        nextFireTime = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        enemyShoot = this;
	}
	
	
	void Update () {
	
	}
    public void Shoot()
    {
        transform.LookAt(player.transform);
        if (Time.time >= nextFireTime)
        {
            //EnemyProjectile newpProjectile = Instantiate(projectile, muzzle.position, muzzle.rotation) as EnemyProjectile;
           // newpProjectile.SetSpeed(bulletSpeed);
            nextFireTime = Time.time + firerate;
        }
        
    }
}
