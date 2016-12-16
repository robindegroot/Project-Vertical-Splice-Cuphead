using UnityEngine;
using System.Collections;

public class EnemySight : EnemyShoot
{
	public int range;
	float distance;
	float distance1;
	public Transform target;
    public EnemyShoot enemyShoot;
	void Update () 
	{
		distance = target.position.x - transform.position.x;

		if(distance < 0)
		{
			distance1 = distance * -1;
			if(range > distance1)
			{
                Debug.Log("links");
                enemyShoot = GetComponent<EnemyShoot>();
                enemyShoot.Shoot();
			}
		}
		if(distance > 0)
		{
			if(range > distance)
			{
                Debug.Log("rechts");
                enemyShoot = GetComponent<EnemyShoot>();
                enemyShoot.Shoot();
            }
		}
	}
}
