using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour

{
    // Variables

    private float magSize = 6f;
    private float currentAmmo;
    public bool Reloading;
    private float reloadDelay;
    public float launchForce = 1f; // Changing this value seemingly does nothing, I have no idea why

    // References

    private ParticleSystem Chain;
    public Rigidbody Projectile;
    public GameObject firePoint;
    public Text ammoReadOut;
    //private Ray chainDirection;

    // Functions

    private void Start()
    {
        // All variables set to default values at the beginning of the game.
        currentAmmo = magSize;
        
        Reloading = false;
    }

    private void Update()
        {
            reloadDelay += Time.deltaTime;
            // On left mouse button down, fire.
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();            
            }

            CheckReload();

            // on pressing "R", trigger the reload cycle manually, but only if there are less bullets than the magazine size.
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentAmmo < magSize)
                {
                    Reloading = true;
                }
            }
        ammoReadOut.text = "Ammo : " + currentAmmo;
        }

    // Create an instance of the projectile at same position and rotation as the firing point.
    private void Fire()
    {
        // You can fire until the magazine is empty, at which point it automatically triggers the reloading cycle, during which you cannot fire.
        if (Reloading == false)
        {
            if (currentAmmo > 0)
            {
                Rigidbody projInstance = Instantiate(Projectile, firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
                projInstance.velocity = launchForce * firePoint.transform.forward;

                currentAmmo--;
            }
            else
            {
                Reloading = true;
            }
        }
    }

    private void CheckReload()
    {

        // Add a bullet after a short delay on loop until the current ammunition is equal to the magazine size.
        if (Reloading == true && reloadDelay > 0.1f)
        {
            reloadDelay = 0f;
            currentAmmo++;            
            if (currentAmmo == magSize)
            {
                Reloading = false;
            }
        }
    }
}
