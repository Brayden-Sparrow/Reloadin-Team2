using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Variables

    public float dampTime = 0.2f;

    // References

    public GameObject door1;
    public GameObject door2;
    public GameObject key1;
    public GameObject key2;

    // Functions

    void Start()
    {
        key1.SetActive(true);
        key2.SetActive(true);
        door1.SetActive(true);
        door2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyStatus(); 
    }

    private void CheckKeyStatus()
    {
        if (key1.activeInHierarchy == false)
        {
            door1.SetActive(false);
        }

        if (key2.activeInHierarchy == false)
        {
            door2.SetActive(false);
        }
    }
}
