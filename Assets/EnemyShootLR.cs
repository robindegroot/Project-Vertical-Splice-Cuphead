using UnityEngine;
using System.Collections;

public class EnemyShootLR: MonoBehaviour
{
	public int _range;
	float distance;
	public bool active;
	float distance1;
	public Transform _target;
	private float Rotation;

	void Update () 
	{
		
		transform.eulerAngles = new Vector3 (0, 0, 45 * Rotation);
		distance = _target.position.x - transform.position.x;
		//Debug.Log (distance);
		if(distance < 0)
		{
			distance1 = distance * -1;
			if (_range > distance1) {
				active = true;
				//Debug.Log (active);
				Rotation = 0.1f;
			} else if (_range < distance1) {
				active = false;
			}
		}
		if(distance > 0)
		{
			active = true;
			if(_range > distance)
			{
				Rotation = 7.9f;
			}else if (_range < distance) {
				active = false;
			}
		}
	}
}
