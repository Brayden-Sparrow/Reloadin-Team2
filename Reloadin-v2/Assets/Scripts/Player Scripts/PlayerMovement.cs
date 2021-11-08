using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables

    [Header("Magnitude")]
    [SerializeField] private float walkSpeed = 5f;

    [Header("Direction")]
    private Vector3 moveDirection;

    private Vector3 velocity;

    [SerializeField] private float jumpHeight = 2;

    [Header("Other")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundDistance = 0.1f;
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
        Look();
    }

    // Script to move the player character depending on the input from the player.
    private void Move()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundMask);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection *= walkSpeed;

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        characterController.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    private void Look()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Stores hit information
        RaycastHit hit;

        // Test to see if the ray hit the ground ignoring everything else.
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            var lookPos = hit.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
    }
}
