using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float maxLifeTime = 4f;
    private float impactLifeTime = 1f;
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

    private void OnColliderEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            LockChain();
            Debug.Log(other.gameObject);
            //doomedEnemy[i] = other.gameObject;
            Destroy(gameObject, impactLifeTime);
        }

        if (other.tag == "Default")
        {
            Destroy(gameObject, impactLifeTime);
        }

        else
        {
            return;
        }
    }
}
