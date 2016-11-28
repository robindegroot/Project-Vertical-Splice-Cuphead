using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour 
{
	int live = 3;

	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "enemy") 
		{
			Hit ();
		}
	}

	void Hit ()
	{
		live--;
		if (live == 0) 
		{
			Debug.Log ("dood");
		} 
	}
}