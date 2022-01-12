using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TripWirecontroller : MonoBehaviour
{
    // When the player makes contact with the trip wire, load the end scene.
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Outro");
    }
}
