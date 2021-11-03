using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables

    [Header("Magnitude")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed = 5f;
    
    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    


    // References

    private CharacterController characterController;

    // Functions

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    // Script to move the player character depending on the input from the player.
    private void Move()
    {
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(0, 0, moveZ) * walkSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
