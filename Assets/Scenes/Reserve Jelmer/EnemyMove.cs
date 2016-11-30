using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour 
{
	public float Speed;
	public int MinX;
	public int MaxX;

	bool Move = true;

	void Update () 
	{
		if (MaxX < this.transform.position.x)
		{
			Move = true;
		}
		if (MinX > this.transform.position.x)
		{
			Move = false;
		}

		if (Move == true) 
		{
			transform.Translate (Vector3.left * Speed * Time.deltaTime);
		}
		if (Move == false) 
		{
			transform.Translate (Vector3.right * Speed * Time.deltaTime);
		}
	}
}