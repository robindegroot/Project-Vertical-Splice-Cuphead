using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
	//moeten we helemaal verander
    private float speed;

	
	void Start ()
    {
        Destroy(gameObject, 15f);
	}
	
	
	void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
    public void SetSpeed(float value)
    {
        speed=value;
    }
    private void OnTriggerEnter(Collider other)
    {
     
    }
}
