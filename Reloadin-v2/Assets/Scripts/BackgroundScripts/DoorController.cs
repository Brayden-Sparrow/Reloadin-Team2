using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Variables

    // References

    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public GameObject door5;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;

    // Functions

    void Start()
    {
        key1.SetActive(true);
        key2.SetActive(true);
        key3.SetActive(true);
        key4.SetActive(true);
        door1.SetActive(true);
        door2.SetActive(true);
        door3.SetActive(true);
        door4.SetActive(true);
        door5.SetActive(true);
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
        if (key3.activeInHierarchy == false)
        {
            door3.SetActive(false);
        }
        if (key4.activeInHierarchy == false)
        {
            door4.SetActive(false);
        }
        if (key5.activeInHierarchy == false)
        {
            door5.SetActive(false);
        }
    }
}
