using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Variables

    private float maxHealth = 1f;
    public float currentHealth;


    // References

    public GameObject healthBarRed; // Actual Health
    public GameObject healthBarWhite; // Health Bar Background

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    private void checkHealth()
    {
        // This is your problem Brayden, sorry.
        float healthRatio = currentHealth / maxHealth;

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Real Bullet")
        {
            Destroy(gameObject);
        }
    }

}
