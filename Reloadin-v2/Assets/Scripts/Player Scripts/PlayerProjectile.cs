using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float maxLifeTime = 4f;
    private GameObject[] EnemyHealth;

    // References

    private EnemyHealth dEnemy;

    // Functions

    void Awake()
    {
        Destroy(gameObject, maxLifeTime);
    }


    private void LockChain()
    {
        // Activate the line drawing element on the enemy object.

    }

    private void OnCollisionEnter(Collision other)
    {
        
            if (other.gameObject.tag == "Enemy_3")
            {
                dEnemy = other.gameObject.GetComponent<EnemyHealth>();
                Debug.Log(other.gameObject.transform.position);
            }       

            else if (other.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
    }
}
