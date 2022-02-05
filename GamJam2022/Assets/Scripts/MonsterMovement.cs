using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

//based on https://www.youtube.com/watch?v=_QajrabyTJc
//if code below doesn't work I will create movement with this tutorial https://www.youtube.com/watch?v=p-3S73MaDP8&t=1s
public class MonsterMovement : MonoBehaviour
{
    //this for u tom yes?
    Vector3 velocity;
    public float current_speed; //probably u want a float aye? - I convert velocipy into this
    public bool is_attacking;

    float attack_cooldown = 2.0f; // to be tweaked

    MonsterControls ControllerInputs;

    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public LayerMask groundMask;
    bool isGrounded;

    float attack_timer = 0;

    Vector2 controller_move;
    Vector2 controller_rotate;

    float xRotation = 0.0f;

    Camera MonsterCam;

    private void Awake() {
        ControllerInputs = new MonsterControls();

        ControllerInputs.GamePlay.Jump.performed += ctx => Jump();
        ControllerInputs.GamePlay.Attack.performed += ctx => Attack();

        ControllerInputs.GamePlay.Move.performed += ctx => controller_move = ctx.ReadValue<Vector2>();
        ControllerInputs.GamePlay.Move.canceled += ctx => controller_move = Vector2.zero;    

        ControllerInputs.GamePlay.Rotate.performed += ctx => controller_rotate = ctx.ReadValue<Vector2>();
        ControllerInputs.GamePlay.Rotate.canceled += ctx => controller_rotate = Vector2.zero;

        MonsterCam = transform.GetComponentInChildren<Camera>();
    }

    private void OnEnable() {
        ControllerInputs.Enable();
    }

    public void Update() {
        current_speed = controller.velocity.magnitude;
        Movement();
        attack_timer += Time.deltaTime;
    }

    private void Movement() {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * controller_move.x + transform.forward * controller_move.y;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Vector2 r = new Vector2(-controller_rotate.y, -controller_rotate.x) * 100.0f * Time.deltaTime;

        xRotation += controller_rotate.y;
        xRotation = Mathf.Clamp(xRotation, -40.0f, 40.0f);

        MonsterCam.transform.localRotation = Quaternion.Euler(-xRotation , 0, 0);
        transform.Rotate(Vector3.up * controller_rotate.x);

    }

    private void Jump() {
        if (isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void Attack() {
        if (attack_timer > attack_cooldown) {
            is_attacking = false;
        }
        if (!is_attacking) {
            is_attacking = true;
            attack_timer = 0;
        }
    }
}
