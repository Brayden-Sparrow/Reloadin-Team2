using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float shotSpeed = 10f;
    private float maxLifeTime = 4f;
    private float chainNumber = 1f;

    // References


    // Functions

    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    
    void Update()
    {
        Vector3 movement = (transform.forward * shotSpeed * Time.deltaTime);
    }

    private void LockChain()
    {
        // Activate the line drawing element on the enemy object

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            LockChain();
        }
        else
        {
            return;
        }
    }
}
