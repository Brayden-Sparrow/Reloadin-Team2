using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Variables

    public float dampTime = 0.2f;
    private Vector3 playerPosition;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;

    // References

    public Camera mainCamera;
    public Transform Player;
    public GameObject cameraBase;

    // Functions

    void Update()
    {
        CheckPosition();
        MoveCamera();
    }

    private void CheckPosition()
    {
        playerPosition = Player.transform.position;
    }

    private void MoveCamera()
    {
        // mainCamera.transform.position = (playerPosition + cameraBase.transform.position);
        desiredPosition = Player.position + cameraBase.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }
}
