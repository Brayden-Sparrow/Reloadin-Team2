using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Variables

    public float dampTime = 0.2f;
    private bool doorAccess1;
    private bool doorAccess2;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;

    // References

    private GameObject door1;
    private GameObject door2;
    private Transform doorOne;
    private Transform doorTwo;
    private GameObject door1Rise;
    private GameObject door2Rise;

    // Functions

    void Start()
    {
        doorAccess1 = false;
        doorAccess2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyStatus();
    }

    private void CheckKeyStatus()
    {
        if (doorAccess1 == true)
        {
            desiredPosition = doorOne.position + door1Rise.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
        }

        if (doorAccess2 == true)
        {
            desiredPosition = doorTwo.position + door2Rise.transform.position;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
        }
    }
}
