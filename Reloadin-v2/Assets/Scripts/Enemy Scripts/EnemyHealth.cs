using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    // Variables

    private float maxHealth;
    public float currentHealth;


    // References

    public Transform healthBarRed; // Actual Health
    public Transform healthBarWhite; // Health Bar Background

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
        //healthBarRed.transform.localScale.x(Vector3 maxHealth, maxHealth/currentHealth * healthBarWhite.transform.localScale.x);
    }
}
