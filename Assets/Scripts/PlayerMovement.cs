using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Component playerSounds;
    private Animator animator;
    
    private Vector3 playerVelocity;
    private Vector3 spawnPosition;
    
    private readonly int speedHash = Animator.StringToHash("Speed");
    private readonly int strafeHash = Animator.StringToHash("Strafe");
    private readonly int jumpHash = Animator.StringToHash("Jump");
    private bool groundedPlayer;
    private float num;
    private float playerSpeedDiagonal;

    public string surface;
    
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private GameObject spawn;
    
    

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerSounds = GetComponent<PlayerSounds>();
        animator = GetComponent<Animator>();
        num = (float) Math.Sqrt(2);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -5f;
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
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -6.0f * gravityValue);
            animator.SetTrigger(jumpHash);
        }
        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        animator.SetFloat(speedHash, moveZ);
        animator.SetFloat(strafeHash, moveX);

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (playerSpeed != 100f)
            {
                playerSpeed = 100f;
            }
            else
            {
                playerSpeed = 10f;
            }


        }

    }

    public void TeleportPlayer()
    {
        spawnPosition = spawn.transform.position;
        spawnPosition.y += 2f;
        playerSounds.SendMessage("Drop");
        controller.enabled = false;
        transform.position = spawnPosition;
        controller.enabled = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name == "Sphere")
        {
            TeleportPlayer();
        }

        surface = hit.gameObject.name;
    }
    
    
}