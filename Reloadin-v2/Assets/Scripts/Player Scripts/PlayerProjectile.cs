using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float maxLifeTime = 4f;
    //private float chainNumber = 1f;
    private GameObject[] doomedEnemy;


    // References

    // Functions

    void Awake()
    {
        Destroy(gameObject, maxLifeTime);
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
            Debug.Log(other.gameObject);
            //doomedEnemy[i] = other.gameObject;
            Destroy(gameObject, 0.1f);
        }

        else
        {
            return;
        }
    }
}
