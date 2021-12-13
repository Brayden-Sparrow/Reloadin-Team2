using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomedEnemy : MonoBehaviour
{
    // Variables

    public float doomedStatus;

    //References

    public PlayerShooting pShooting;
    // private EnemyHealth eHealth;

    // Functions
    
    void Start()
    {
        doomedStatus = 0;
    }

    
    void Update()
    {
        checkReloadStatus();
    }

    private void checkReloadStatus()
    {
        if (pShooting.Reloading == true)
        {
            //eHealth = Mathf.Abs(eHealth.currentHealth - doomedStatus);
            doomedStatus = 0;
        }
        else
        {
            return;
        }
    }
}
