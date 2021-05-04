using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int strafeHash = Animator.StringToHash("Strafe");
    private readonly int jumpHash = Animator.StringToHash("Jump");
    private Animator animator;
    private bool groundedPlayer;
    private float num;
    private float playerSpeedDiagonal;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        num = (float) Math.Sqrt(2);
    }

    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        float moveZ = Input.GetAxis("Vertical");
        float moveX = Input.GetAxis("Horizontal");

        Vector3 move = new Vector3(moveX, 0, moveZ);

        move = transform.TransformDirection(move);
        if (moveZ != 0 && moveX != 0)
        {
            playerSpeedDiagonal = playerSpeed / num;
            controller.Move(playerSpeedDiagonal * Time.deltaTime * move);
        }
        else
        {
            controller.Move(playerSpeed * Time.deltaTime * move);
        }

        


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.SetTrigger(jumpHash);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        animator.SetFloat(speedHash, moveZ);
        animator.SetFloat(strafeHash, moveX);
    }
}