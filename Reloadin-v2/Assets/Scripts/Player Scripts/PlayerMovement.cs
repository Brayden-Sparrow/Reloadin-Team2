using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables

    [Header("Magnitude")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float walkSpeed;

    [Header("Direction")]
    private Vector3 moveDirection;

    private Vector3 velocity;

    [SerializeField] private float jumpHeight = 2;

    [Header("Other")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundDistance = 0.1f;
    [SerializeField] private LayerMask Ground;
    [SerializeField] private float gravity;
    [SerializeField] private Vector3 targetPosition;
    public GameObject BeholderEye;

    // References

    private CharacterController characterController;

    // Functions

    private void Awake()
    {
        // Ignores everything except the ground
        Ground = LayerMask.GetMask("Ground");

    }

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
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, Ground);

        if (isGrounded == true && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        walkSpeed = movementSpeed * Time.deltaTime;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        moveDirection = new Vector3(moveX, 0, moveZ);
        moveDirection *= walkSpeed;

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //characterController.Move(moveDirection * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        //characterController.Move(velocity * Time.deltaTime);
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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Ground))
        {
            // Lock the y.axis and save the x and z position
            targetPosition = new Vector3 (hit.point.x, transform.position.y, hit.point.z);

            // Rotate the eye
            BeholderEye.transform.LookAt(targetPosition);
        }

    }
}
