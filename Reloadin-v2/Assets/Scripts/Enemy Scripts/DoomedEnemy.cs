using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DoomedEnemy : MonoBehaviour
{
    // Variables

    public float doomedStatus;

    //References

    public PlayerShooting pShooting;
    public GameObject effectImage;
    public Text effectAmount;
    private EnemyHealth eHealth;

    // Functions
    
    void Start()
    {
        doomedStatus = 0;        
        eHealth = gameObject.GetComponent<EnemyHealth>();
    }

    
    void Update()
    {
        checkReloadStatus();
        checkDoomStatus();
    }

    private void checkDoomStatus()
    {
        if (doomedStatus > 0)
        {
            effectImage.SetActive(true);
            effectAmount.text = "X" + doomedStatus;
        }
        else
        {
            effectImage.SetActive(false);
            effectAmount.text = "";
        }
    }

    private void checkReloadStatus()
    {
        if (pShooting.Reloading == true && doomedStatus > 0)
        {
            Mathf.Abs(eHealth.currentHealth -= doomedStatus);
            doomedStatus = 0;
        }
        else
        {
            return;
        }
    }
}
