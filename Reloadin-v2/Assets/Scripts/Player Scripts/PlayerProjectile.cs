using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float shotSpeed = 10f;
    private float maxLifeTime = 4f;
    private float chainNumber = 1f;
    private Vector3 currentPosition;

    // References

    // Functions

    void Awake()
    {
        Destroy(gameObject, maxLifeTime);
    }


    void Update()
    {
        
    }

    private void LockChain()
    {
        // Activate the line drawing element on the enemy object.

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

    private void BulletMove()
    {

    }
}
