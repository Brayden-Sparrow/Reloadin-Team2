using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    // Variables

    private float maxLifeTime = 4f;
    private GameObject[] doomedEnemy;

    // References

    private DoomedEnemy dEnemy;

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
        
            if (other.gameObject.tag == "Enemy")
            {
                dEnemy = other.gameObject.GetComponent<DoomedEnemy>();
                dEnemy.doomedStatus++;
                Debug.Log(other.gameObject.transform.position);
            }       

            else if (other.gameObject.tag != "Player")
            {
                Destroy(gameObject);
            }
    }
}
