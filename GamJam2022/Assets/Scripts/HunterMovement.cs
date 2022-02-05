using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//based on https://www.youtube.com/watch?v=_QajrabyTJc
public class HunterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform groundCheck;
    public int hunterHealth = 10;
    public float groundDistance = 0.2f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;
    public LayerMask groundMask;
    bool isGrounded;

    public TextMeshProUGUI healthDisplay;

    void Update()
    {
        Screen.lockCursor = true;

        Movement();
        healthDisplay.SetText("Health: " + hunterHealth);
    }

    private void Movement()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = 0.0f;
        float z = 0.0f;

        if (Keyboard.current.wKey.IsPressed()) {
            z = 1.0f;
        }
        else if (Keyboard.current.sKey.IsPressed()) {
            z = -1.0f;
        }

        if (Keyboard.current.dKey.IsPressed()) {
            x = 1.0f;
        }
        else if (Keyboard.current.aKey.IsPressed()) {
            x = -1.0f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
