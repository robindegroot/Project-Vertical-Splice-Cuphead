using UnityEngine;
using System.Collections;

public class EnemyJump : MonoBehaviour 
{
	public int jumpPower;
	float timeLeft = 3;

	void Update () 
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			jump();
		}
	}
	void jump ()
	{
		GetComponent<Rigidbody2D>().AddForce(transform.up * jumpPower * Time.deltaTime);
		timeLeft = 10;
	}
}