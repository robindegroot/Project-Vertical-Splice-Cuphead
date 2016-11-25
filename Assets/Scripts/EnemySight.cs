using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	public int range;
	float distance;
	float distance1;
	public Transform target;

	void Update () 
	{
		distance = target.position.x - transform.position.x;
		//Debug.Log (distance);
		if(distance < 0)
		{
			distance1 = distance * -1;
			if(range > distance1)
			{
				//schiet link
			}
		}
		if(distance > 0)
		{
			if(range > distance)
			{
				//schiet rechts
			}
		}
	}
}
