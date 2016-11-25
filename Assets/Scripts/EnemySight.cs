using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    public RaycastHit hit;
    private GameObject player;
  

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("PlayerParts"))
        {

            Vector3 direction = other.transform.position - transform.position;

            if (Physics.Raycast(transform.position, direction.normalized, out hit))
            {

                if (hit.collider.gameObject == player)
                {

                    if (hit.distance > 60)
                    {
                        ai.Chase();
                    }
                    if (hit.distance <= 40)
                    {
                        ai.Attack();
                    }
                }
            }
            else
            {
                ai.Idle();
            }
        }

    }
}