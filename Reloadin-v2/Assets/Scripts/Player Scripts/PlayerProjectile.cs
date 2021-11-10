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
        
    }

    
    void Update()
    {
        Vector3 movement = (transform.forward * shotSpeed * Time.deltaTime);
    }

    private void LockChain()
    {

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
