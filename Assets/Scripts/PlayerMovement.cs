using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpHeight;
	[SerializeField] private float gravity;
	[SerializeField] private float groundCheckDistance;
	[SerializeField] private LayerMask groundMask;
	

	private Vector3 moveDirection;
	private Vector3 velocity;
	

	private CharacterController controller;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		float moveZ = Input.GetAxis("Vertical");
		float moveX = Input.GetAxis("Horizontal");

		moveDirection = new Vector3(moveX, 0, moveZ);
		moveDirection *= moveSpeed;
		moveDirection = transform.TransformDirection(moveDirection);
		if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			moveDirection.y = jumpHeight;
		}
		
		
		controller.Move(moveDirection * Time.deltaTime);
	}
	
}
